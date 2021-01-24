using UnityEngine;

public class Drone : MonoBehaviour
{
    public float Speed;
    public float MaxHeight;

    private Vector3 _upPosition;
    private Vector3 _downPosition;

    void Start()
    {

    }

    public void ApplyStrategy(IManeuverBehaviour strategy)
    {
        strategy.Maneuver(this);
    }

    void Update()
    {
        /**
        Debug.DrawRay(transform.position, _rayDirection, Color.blue);
        if (Physics.Raycast(transform.position, _rayDirection, out _hit, _rayDistance))
        {
            if (_hit.collider.GetComponent<BikeController>())
            {
                Debug.DrawRay(transform.position, _rayDirection, Color.green);
                _hit.collider.GetComponent<BikeController>().ToggleNightVision();
            }
        }
        **/
    }
}