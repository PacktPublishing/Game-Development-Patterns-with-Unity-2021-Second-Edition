using UnityEngine;

namespace FPP.Scripts.Ingredients.Bike.States
{
    public class BikeStartState : StateMachineBehaviour
    {
        private BikeController _bikeController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_bikeController)
                _bikeController = animator.GetComponent<BikeController>();

            if (_bikeController)
            {
                _bikeController.BikeEngine.TurnOn();
                _bikeController.Notify();
            }
            else
            {
                Debug.LogError("Missing controller!");
            }
        }
    }
}