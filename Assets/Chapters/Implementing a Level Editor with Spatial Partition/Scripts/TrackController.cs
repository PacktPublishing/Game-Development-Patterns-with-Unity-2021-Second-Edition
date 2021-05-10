using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Chapter.SpatialPartition
{
    public class TrackController: MonoBehaviour
    {
        private Track _track;
        private float _trackSpeed;
        private bool _isTrackLoaded;
        private GameObject _trackParent;
        private Transform _segmentParent;
        private GameObject _previousSegment;
        private Stack<GameObject> _segmentStack;
        private Vector3 _segmentPosition = new Vector3(0, 0, 0);

        [Range(0.0f, 100.0f)]
        [SerializeField]
        private float speedDampener;
        
        [SerializeField]
        private List<Track> tracks = new List<Track>();
        
        [SerializeField]
        private int initSegmentAmount;
        
        [SerializeField]
        private int incrSegmentAmount;

        void Awake()
        {
            _track = tracks[0];
            LoadTrack();
        }

        void Update()
        {
            if (_isTrackLoaded)
                _segmentParent.transform.Translate(Vector3.back * (_trackSpeed * Time.deltaTime));
        }

        private void LoadTrack()
        {
            _isTrackLoaded = false;

            Destroy(_trackParent);

            _trackParent = 
                Instantiate(Resources.Load("Track", typeof(GameObject))) as GameObject;
            
            if (_trackParent)
                _segmentParent = _trackParent.transform.Find("Segments");

            List<GameObject> reverseList = 
                Enumerable.Reverse(_track.segments).ToList();
            
            _segmentStack = new Stack<GameObject>(reverseList);

            _previousSegment = null;
            LoadSegment(initSegmentAmount);

            _isTrackLoaded = true;
        }

        private void LoadSegment(int amount)
        {
            if (_segmentStack.Count > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    GameObject segment = 
                        Instantiate(_segmentStack.Pop(), _segmentParent.transform);

                    if (!_previousSegment) 
                        _segmentPosition.z = 0;

                    if (_previousSegment)
                        _segmentPosition.z =
                            _previousSegment.transform.position.z + _track.segmentSize;

                    segment.transform.position = _segmentPosition;
                    segment.GetComponent<Segment>().trackController = this;
                    _previousSegment = segment;
                }
            }
        }

        public void LoadNextSegments()
        {
            LoadSegment(incrSegmentAmount);
        }
    }
}