using UnityEngine;
using FPP.Scripts.Controllers;

public class DestroyState : MonoBehaviour, IBikeState
{
    public void Handle(BikeController bikeController)
    {
        Debug.Log("Destroyed");
    }
}