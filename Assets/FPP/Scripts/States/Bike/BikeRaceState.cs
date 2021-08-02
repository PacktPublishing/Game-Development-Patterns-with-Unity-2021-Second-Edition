using UnityEngine;
using FPP.Scripts.Controllers;

public class BikeRaceState : StateMachineBehaviour
{
    private BikeController _bikeController;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bikeController = animator.GetComponent<BikeController>();

        if (_bikeController)
        {
            _bikeController.bikeEngine.TurnOn();
            _bikeController.currentSpeed = _bikeController.bike.defaultSpeed;
            _bikeController.Notify();
        }
    }
}