using UnityEngine;
using System.Collections.Generic;

public class ClientStrategy : MonoBehaviour
{
    private GameObject _drone;
    private List<IManeuverBehaviour> _components = new List<IManeuverBehaviour>();
    
    void Start()
    {
        _drone = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _drone.AddComponent<Drone>();
        
        _components.Add(_drone.AddComponent<WeavingManeuver>());
        _components.Add(_drone.AddComponent<BoppingManeuver>());
        _components.Add(_drone.AddComponent<FallbackManeuver>());
        
        int index = Random.Range(0, _components.Count);
        _drone.GetComponent<Drone>().ApplyStrategy(_components[index]);
    }
}