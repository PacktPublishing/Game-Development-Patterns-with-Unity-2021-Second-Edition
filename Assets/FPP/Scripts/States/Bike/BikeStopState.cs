using UnityEngine;
using FPP.Scripts.Controllers;

public class BikeStopState : StateMachineBehaviour
{
    private BikeController _bikeController;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bikeController = animator.GetComponent<BikeController>();

        if (_bikeController)
        {
            _bikeController.currentSpeed = 0;
            _bikeController.Notify();
        }
    }
}
