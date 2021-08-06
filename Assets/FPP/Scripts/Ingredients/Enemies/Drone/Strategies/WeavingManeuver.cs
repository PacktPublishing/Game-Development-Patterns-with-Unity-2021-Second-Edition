using UnityEngine;

namespace FPP.Scripts.Ingredients.Enemies.Drone.Strategies
{
    public class WeavingManeuver : MonoBehaviour, IManeuverBehaviour // TODO: This needs to be converted from a strategy class to a animation state class
    {
        public void Maneuver(DroneController droneController)
        {
            if (droneController.Animator)
                droneController.Animator.SetTrigger("Weave");
            else
                Debug.LogError("Drone animator missing!");
        }
    }
}