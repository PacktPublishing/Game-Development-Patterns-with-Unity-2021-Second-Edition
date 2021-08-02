using UnityEngine;
using FPP.Scripts.Controllers;

public class TurnLeftState : MonoBehaviour, IBikeState
{
    public void Handle(BikeController bikeController)
    {
        if (bikeController.bikeSensor.CheckCollision(BikeDirection.Left))
        {

            bikeController.Damage(DamageType.Collision);
        }
        else
        {


        }
    }
}