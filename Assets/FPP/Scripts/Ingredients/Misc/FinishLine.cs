using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using FPP.Scripts.Ingredients.Bike;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BikeController>()) 
            RaceEventBus.Publish(RaceEventType.FINISH);
    }
}