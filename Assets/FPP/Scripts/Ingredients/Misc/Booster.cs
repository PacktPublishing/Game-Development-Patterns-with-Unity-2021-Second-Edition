using UnityEngine;
using FPP.Scripts.Controllers;

public class Booster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<BikeController>().ToggleTurbo();
    }
}
