using UnityEngine;
using FPP.Scripts.Enums;

public class BikeSensor : MonoBehaviour
{
    public bool isDebugOn;
    
    private RaycastHit _hit;
    private LayerMask _layer;
    private Vector3 _startPosition;
    
    [Range(0.0f, 90.0f)]
    [SerializeField] private float sideDetectionAngle;
    [SerializeField] private float sideDetectionDistance; 
    [SerializeField] private float forwardDetectionDistance; 
    
    void Start()
    {
        _layer = LayerMask.GetMask("Obstacles");
    }
    
    void Update()
    {
        if (isDebugOn)
        {
            _startPosition = transform.position;
            
            Debug.DrawRay(_startPosition, GetForwardDirection(BikeDirection.Left) * sideDetectionDistance, Color.blue);
            Debug.DrawRay(_startPosition, GetForwardDirection(BikeDirection.Right) * sideDetectionDistance, Color.blue);
            Debug.DrawRay(_startPosition, GetForwardDirection(BikeDirection.Forward) * forwardDetectionDistance, Color.blue);
        }
    }
    
    public bool IsSensingCollision(BikeDirection direction)
    {
        if (Physics.Raycast(_startPosition, GetForwardDirection(direction), out _hit, sideDetectionDistance, _layer)) 
            return true;
        return false;
    }

    private Vector3 GetForwardDirection(BikeDirection direction)
    {
        return Quaternion.Euler(0.0f, sideDetectionAngle * (int) direction, 0f) * Vector3.forward;;
    }
}