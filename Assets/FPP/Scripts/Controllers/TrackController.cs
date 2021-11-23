using UnityEngine;
using System.Linq;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using System.Collections.Generic;
using FPP.Scripts.Ingredients.Bike;
using FPP.Scripts.Ingredients.Track;

namespace FPP.Scripts.Controllers
{
    public class TrackController : Observer
    {
        private bool _isReplaying;
        private float _trackSpeed;
        private bool _isTrackLoaded;
        private int _currentActiveRail;
        private int _currentTrackIndex;
        private GameObject _trackParent;
        private Transform _segmentParent;
        private List<GameObject> _segments;
        private Transform _previousSegment;
        private Stack<GameObject> _segmentStack;
        private Vector3 _currentPosition = new (0, 0, 0);
        
        [Tooltip("List of race tracks")]
        [SerializeField]
        public List<RaceTrack> tracks = new();
        
        [Tooltip("Number of rails per track")] 
        [SerializeField]
        private int railAmount; // TODO: This should be customizable thru a property in RaceTrack scriptable objects.
        
        [Tooltip("Starting line rail number")] 
        [SerializeField]
        private int startingRail;
        
        [Tooltip("Dampen the speed of the track")] 
        [Range(0.0f, 100.0f)] 
        [SerializeField]
        private float speedDampener;
        
        [Tooltip("Initial amount of segment to load at start")] 
        [SerializeField]
        private int initialSegmentAmount;

        [Tooltip("Amount of incremental segments to load at run")] 
        [SerializeField]
        private int incrementalSegmentAmount;
        
        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.REPLAY, ReplayTrack);
            RaceEventBus.Subscribe(RaceEventType.RESTART, RestartTrack);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.REPLAY, ReplayTrack);
            RaceEventBus.Unsubscribe(RaceEventType.RESTART, RestartTrack);
        }

        private void Awake()
        {
            ReserveTrackSegments();
        }

       private void Start()
        {
            _currentActiveRail = startingRail;
        }

        private void Update()
        {
            if (_segmentParent)
                _segmentParent.transform.Translate(Vector3.back * (_trackSpeed * Time.deltaTime));
        }

        public bool IsNextRailAvailable(BikeDirection direction) // TODO: Remove conditions and use bike direction enums values to evaluate rail availability. 
        {
            if (direction == BikeDirection.Left)
            {
                if (_currentActiveRail != 1)
                {
                    _currentActiveRail -= 1;
                    return true;
                }
            }
            
            if (direction == BikeDirection.Right)
            {
                if (_currentActiveRail != railAmount) 
                {
                    _currentActiveRail += 1;
                    return true;
                }
            }

            return false;
        }

        public void LoadNextTrack(int trackIndex)
        {
            _currentActiveRail = startingRail;
            
            _isReplaying = false;

            _currentTrackIndex = 1;

            ReserveTrackSegments();
            
            InitTrack(trackIndex);
        }

        private void ReserveTrackSegments()
        {
            _segments = Enumerable.Reverse(tracks[_currentTrackIndex].segments).ToList();
        }

        private void ReplayTrack() // TODO: Rename this method, it's not clear the difference between restart and replay.
        {
            _currentActiveRail = startingRail;
            
            _isReplaying = true;

            InitTrack(_currentTrackIndex);
        }
        
        private void RestartTrack()
        {
            _currentActiveRail = startingRail;
            
            _isReplaying = false;
            
            InitTrack(_currentTrackIndex);
        }

        public void InitTrack(int trackIndex)
        {
            _currentTrackIndex = trackIndex;
            
            if (!_isReplaying)
            {
                Destroy(_trackParent);

                _trackParent = Instantiate(Resources.Load("BaseTrack", typeof(GameObject))) as GameObject;

                if (_trackParent != null)
                    _segmentParent = _trackParent.transform.Find("Segments");
            }
            else
            {
                _trackParent.GetComponent<BaseTrack>().ResetBikeToSpawnPoint();
            }

            _previousSegment = null;
            
            _segmentStack = new Stack<GameObject>(_segments);
            
            LoadSegment(initialSegmentAmount);
            
            if (!_isReplaying)
                RaceEventBus.Publish(RaceEventType.COUNTDOWN);
        }

        private void LoadSegment(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (_segmentStack.Count > 0)
                {
                    GameObject segment = Instantiate(_segmentStack.Pop(), _segmentParent.transform);

                    if (!_previousSegment) 
                        _currentPosition.z = 0;
                    
                    if (_previousSegment)
                        _currentPosition.z = _previousSegment.position.z + tracks[_currentTrackIndex].segmentLength;

                    segment.transform.position = _currentPosition;
                    
                    segment.AddComponent<TrackSegment>(); 
                    
                    segment.GetComponent<TrackSegment>().trackController = this;
                    
                    _previousSegment = segment.transform;
                }
            }
        }

        public void LoadNextSegment()
        {
            LoadSegment(incrementalSegmentAmount);
        }

        public override void Notify(Subject subject)
        {
            BikeController bikeController = subject.GetComponent<BikeController>();
            
            if (bikeController)
                _trackSpeed = bikeController.CurrentSpeed - (bikeController.CurrentSpeed * speedDampener / 100);
        }
    }
}