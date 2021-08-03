using UnityEngine;
using FPP.Scripts.Controllers;

namespace FPP.Scripts.States.Bike
{
    public class BikeRaceState : StateMachineBehaviour
    {
        private BikeController _bikeController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_bikeController)
                _bikeController = animator.GetComponent<BikeController>();

            if (_bikeController)
            {
                _bikeController.bikeEngine.TurnOn();
                
                _bikeController.currentSpeed =
                    _bikeController.bike.defaultSpeed; // TODO: Speed should be controlled by the BikeEngine
                
                _bikeController.Notify();
            }
            else
            {
                Debug.LogError("Missing controller!");
            }
        }
    }
}