using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

public class DestroyState : MonoBehaviour, IBikeState
{
    public void Handle(BikeController bikeController)
    {
        Debug.Log("Destroyed");
    }
}