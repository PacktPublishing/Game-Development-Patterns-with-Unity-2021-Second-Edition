using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Ingredients.Bike;

public class TurnLeftState : MonoBehaviour, IBikeState
{
    // TODO: This state class needs to be removed
    public void Handle(BikeController bikeController)
    {
        if (bikeController.BikeSensor.CheckCollision(BikeDirection.Left))
        {

            bikeController.TakeDamage(0, DamageType.Collision);
        }
        else
        {


        }
    }
}