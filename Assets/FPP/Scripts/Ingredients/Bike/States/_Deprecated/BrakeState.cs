using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

public class BrakeState : MonoBehaviour, IBikeState
{
    public void Handle(BikeController bikeController)
    {
        bikeController.currentSpeed = 0;
        bikeController.Notify();
    }
}