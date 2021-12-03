using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Cameras;
using FPP.Scripts.Controllers;

namespace FPP.Scripts.Ingredients.Bike.States
{
    public class BikeTurnState : StateMachineBehaviour
    {
        public float bikeTurnDuration;
        public float cameraTurnDuration;
        public BikeDirection direction;

        private BikeSensor _bikeSensor;
        private FollowCamera _followCamera;
        private BikeController _bikeController;
        private TrackController _trackController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_bikeController)
            {
                _bikeController = animator.GetComponent<BikeController>();

                _bikeSensor = _bikeController.BikeSensor;

                _trackController = _bikeController.TrackController;
                
                if (!_followCamera)
                    _followCamera = _bikeController.FollowCamera;
            }
            
            if (_bikeController && _followCamera)
            {
                if (!_bikeSensor.IsSensingCollision(direction))
                {
                    if (_trackController.IsNextRailAvailable(direction))
                    {
                        _followCamera.StartCoroutine(_followCamera.Turn(cameraTurnDuration, direction));
                        _bikeController.StartCoroutine(_bikeController.Turn(bikeTurnDuration, direction));
                    }
                }
                else
                {
                    Debug.Log("Bike turn blocked by side collision!");
                    
                    _bikeController.TakeDamage((int) DamageType.Collision, DamageType.Collision);
                    
                    // TODO: 
                    //      - Play audio sfx
                    //      - Play bike turn cancel animation
                    //      - Penalize player with speed and shield reduction
                }
            }
            else
            {
                Debug.LogError("Missing controller!");
            }
        }
    }
}