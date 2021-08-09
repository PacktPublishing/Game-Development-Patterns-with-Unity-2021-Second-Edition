using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Ingredients.Track
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<BikeController>())
                RaceEventBus.Publish(RaceEventType.FINISH);
        }
    }
}