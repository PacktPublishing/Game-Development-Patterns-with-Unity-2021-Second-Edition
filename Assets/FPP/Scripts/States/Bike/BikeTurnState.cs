using UnityEngine;
using FPP.Scripts.Cameras;
using FPP.Scripts.Controllers;

namespace FPP.Scripts.States.Bike
{
    public class BikeTurnState : StateMachineBehaviour
    {
        public float bikeTurnDuration;
        public float cameraTurnDuration;
        public BikeDirection direction;

        private FollowCamera _followCamera;
        private BikeController _bikeController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_bikeController)
                _bikeController = animator.GetComponent<BikeController>();

            if (!_followCamera)
                _followCamera = _bikeController.followCamera;

            if (_bikeController && _followCamera)
            {
                _followCamera.StartCoroutine(_followCamera.Turn(cameraTurnDuration, direction));
                _bikeController.StartCoroutine(_bikeController.Turn(bikeTurnDuration, direction));
            }
            else
            {
                Debug.LogError("Missing controller!");
            }
        }
    }
}