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
        private float _trackSpeed;
        private bool _isTrackLoaded;
        private GameObject _trackParent;
        private Transform _segmentParent;
        private List<GameObject> _segments;
        private Transform _previousSegment;
        private Stack<GameObject> _segmentStack;
        private Vector3 _currentPosition = new (0, 0, 0);
        
        [Tooltip("List of race tracks")] 
        [SerializeField]
        private RaceTrack track;
        
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
            RaceEventBus.Subscribe(RaceEventType.RESTART, InitTrack);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.RESTART, InitTrack);
        }

        void Awake()
        {
            _segments = Enumerable.Reverse(track.segments).ToList();
        }

        void Start()
        {
            InitTrack();
        }

        void Update()
        {
            _segmentParent.transform.Translate(Vector3.back * (_trackSpeed * Time.deltaTime));
        }

        private void InitTrack()
        {
            Destroy(_trackParent);
            
            _trackParent = Instantiate(Resources.Load("RaceTrack", typeof(GameObject))) as GameObject;
            
            if (_trackParent != null) 
                _segmentParent = _trackParent.transform.Find("Segments");
            
            _previousSegment = null;
            
            _segmentStack = new Stack<GameObject>(_segments);
            
            LoadSegment(initialSegmentAmount);
            
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
                        _currentPosition.z = _previousSegment.position.z + track.segmentLength;

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
            BikeController controller = subject.GetComponent<BikeController>();
            if (controller)
                _trackSpeed = controller.CurrentSpeed - (controller.CurrentSpeed * speedDampener / 100);
        }
    }
}