using UnityEngine;
using FPP.Scripts.Controllers;

public class TurnRightState : MonoBehaviour, IBikeState
{
    public void Handle(BikeController bikeController)
    {
        if (bikeController.bikeSensor.CheckCollision(BikeDirection.Right))
        {

            bikeController.Damage(DamageType.Collision);
        }
        else
        {

        }
    }
}