using UnityEngine;

namespace FPP.Scripts.Ingredients.Bike.States
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
                if (_bikeController.BikeEngine) 
                    _bikeController.BikeEngine.TurnOff();

                _bikeController.Notify();
            }
            else
            {
                Debug.LogError("Missing bike controller!");
            }
        }
    }
}