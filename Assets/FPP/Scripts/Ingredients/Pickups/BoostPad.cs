using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Ingredients.Pickups
{
    public class BoostPad : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BikeController>()) 
                other.GetComponent<BikeController>().ToggleTurbo();
        }
    }
}
