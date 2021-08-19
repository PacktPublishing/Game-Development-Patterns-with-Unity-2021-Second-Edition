using UnityEngine;

namespace FPP.Scripts.Ingredients.Enemies.Drone.Strategies
{
    public class FallbackManeuver : MonoBehaviour, IManeuverBehaviour // TODO: This needs to be converted from a strategy class to a animation state class
    {
        public void Maneuver(DroneController droneController)
        {
            if (droneController.Animator)
                droneController.Animator.SetTrigger("Fallback");
            else
                Debug.LogError("Drone animator missing!");
        }
    }
}