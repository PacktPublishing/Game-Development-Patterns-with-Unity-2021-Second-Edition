using UnityEngine;
using System.Collections.Generic;

public class ClientStrategy : MonoBehaviour
{
    public Drone Drone;
    private List<IManeuverBehaviour> _components = new List<IManeuverBehaviour>();
    
    void Start()
    {
        _components.Add(Drone.gameObject.AddComponent<WeavingManeuver>());
        _components.Add(Drone.gameObject.AddComponent<BoppingManeuver>());
        _components.Add(Drone.gameObject.AddComponent<FallbackManeuver>());
        
        int index = Random.Range(0, _components.Count);
        Drone.ApplyStrategy(_components[index]);
    }
}