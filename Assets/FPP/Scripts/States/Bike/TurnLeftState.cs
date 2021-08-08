using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Controllers;

public class TurnLeftState : MonoBehaviour, IBikeState
{
    // TODO: This state class needs to be removed
    public void Handle(BikeController bikeController)
    {
        if (bikeController.bikeSensor.CheckCollision(BikeDirection.Left))
        {

            bikeController.Damage(0, DamageType.Collision);
        }
        else
        {


        }
    }
}