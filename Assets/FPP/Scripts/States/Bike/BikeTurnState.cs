using UnityEngine;
using FPP.Scripts.Cameras;
using FPP.Scripts.Controllers;

public class BikeTurnState : StateMachineBehaviour
{
    public float bikeTurnDuration;
    public float cameraTurnDuration;
    public BikeController.Direction direction;

    private FollowCamera _followCamera;
    private BikeController _bikeController;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bikeController = animator.GetComponent<BikeController>();
        _followCamera = _bikeController.followCamera;
        
        if (_bikeController)
        {
            _followCamera.StartCoroutine(_followCamera.Turn(cameraTurnDuration, direction));
            _bikeController.StartCoroutine(_bikeController.Turn(bikeTurnDuration, direction));
        }
    }
}