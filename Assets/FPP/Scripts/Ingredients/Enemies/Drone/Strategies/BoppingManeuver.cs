using UnityEngine;

namespace FPP.Scripts.Ingredients.Enemies.Drone.Strategies
{
    public class BoppingManeuver : MonoBehaviour, IManeuverBehaviour // TODO: This needs to be converted from a strategy class to a animation state class
    {
        public void Maneuver(DroneController droneController)
        {
            if (droneController.Animator)
                droneController.Animator.SetTrigger("Bopple");
            else
                Debug.LogError("Animator not found!");
        }
    }
}