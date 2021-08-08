using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Controllers;

public class TurnRightState : MonoBehaviour, IBikeState
{
    // TODO: This state class needs to be removed
    
    public void Handle(BikeController bikeController)
    {
        if (bikeController.bikeSensor.CheckCollision(BikeDirection.Right))
        {

            bikeController.Damage(0, DamageType.Collision);
        }
        else
        {

        }
    }
}