using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using FPP.Scripts.Controllers;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BikeController>()) 
            RaceEventBus.Publish(RaceEventType.FINISH);
    }
}