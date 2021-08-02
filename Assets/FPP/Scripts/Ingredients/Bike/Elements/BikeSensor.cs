using UnityEngine;
using FPP.Scripts.Controllers;

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
            
            Debug.DrawRay(_startPosition, GetForwardDirection(BikeController.Direction.Left) * sideDetectionDistance, Color.blue);
            Debug.DrawRay(_startPosition, GetForwardDirection(BikeController.Direction.Right) * sideDetectionDistance, Color.blue);
            Debug.DrawRay(_startPosition, GetForwardDirection(BikeController.Direction.Forward) * forwardDetectionDistance, Color.blue);
        }
    }
    
    public bool CheckCollision(BikeController.Direction direction)
    {
        if (Physics.Raycast(_startPosition, GetForwardDirection(direction), out _hit, sideDetectionDistance, _layer)) 
            return true;
        return false;
    }

    private Vector3 GetForwardDirection(BikeController.Direction direction)
    {
        return Quaternion.Euler(0.0f, sideDetectionAngle * (int) direction, 0f) * Vector3.forward;;
    }
}