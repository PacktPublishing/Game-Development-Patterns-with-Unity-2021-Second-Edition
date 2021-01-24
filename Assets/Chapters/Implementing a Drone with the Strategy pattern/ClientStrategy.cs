using UnityEngine;

public class ClientStrategy : MonoBehaviour
{
    public Drone Drone;

    // Start is called before the first frame update
    void Start()
    {
        IManeuverBehaviour test = Drone.gameObject.AddComponent<BoppingManeuver>();
        Drone.ApplyStrategy(test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
