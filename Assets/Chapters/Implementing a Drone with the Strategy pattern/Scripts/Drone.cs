using UnityEngine;

namespace Chapter.Strategy
{
    public class Drone : MonoBehaviour
    {
        // Ray parameters
        private RaycastHit _hit;
        private Vector3 _rayDirection;
        [SerializeField] private float _rayAngle = -45.0f;
        [SerializeField] private float _rayDistance = 15.0f;

        // Movement parameters
        [SerializeField] public float Speed = 1.0f;
        [SerializeField] public float MaxHeight = 5.0f;
        [SerializeField] public float WeavingDistance = 1.5f;
        [SerializeField] public float FallbackDistance = 20.0f;

        void Start()
        {
            _rayDirection = transform.TransformDirection(Vector3.back) * _rayDistance;
            _rayDirection = Quaternion.Euler(_rayAngle, 0.0f, 0f) * _rayDirection;
        }

        public void ApplyStrategy(IManeuverBehaviour strategy)
        {
            strategy.Maneuver(this);
        }

        void Update()
        {
            // Drawing a ray to detect target
            Debug.DrawRay(transform.position, _rayDirection, Color.blue);
            if (Physics.Raycast(transform.position, _rayDirection, out _hit, _rayDistance))
            {
                if (_hit.collider)
                {
                    Debug.DrawRay(transform.position, _rayDirection, Color.green);
                    Debug.Log("Hit something");
                }
            }
        }
    }
}