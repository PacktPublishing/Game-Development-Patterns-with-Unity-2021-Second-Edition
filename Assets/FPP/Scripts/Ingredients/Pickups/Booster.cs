using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

public class Booster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<BikeController>().ToggleTurbo();
    }
}
