using UnityEngine;
using FPP.Scripts.Controllers;

public class BrakeState : MonoBehaviour, IBikeState
{
    public void Handle(BikeController bikeController)
    {
        bikeController.currentSpeed = 0;
        bikeController.Notify();
    }
}