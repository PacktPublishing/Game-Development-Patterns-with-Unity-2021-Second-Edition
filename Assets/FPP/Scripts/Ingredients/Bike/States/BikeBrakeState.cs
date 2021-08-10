using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.States.Bike
{
    public class BikeBrakeState : StateMachineBehaviour
    {
        private BikeController _bikeController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_bikeController)
                _bikeController = animator.GetComponent<BikeController>();

            if (_bikeController)
            {
                _bikeController.StopBike();
            }
            else
            {
                Debug.LogError("Missing controller!");
            }
        }
    }
}