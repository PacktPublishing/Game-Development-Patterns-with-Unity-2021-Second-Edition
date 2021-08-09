using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.States.Bike
{
    public class BikeStopState : StateMachineBehaviour
    {
        private BikeController _bikeController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_bikeController)
                _bikeController = animator.GetComponent<BikeController>();

            if (_bikeController)
            {
                _bikeController.currentSpeed = 0; // TODO: The bike's current speed should be controlled by it's engine
                _bikeController.Notify();
            }
            else
            {
                Debug.LogError("Missing controller!");
            }
        }
    }
}