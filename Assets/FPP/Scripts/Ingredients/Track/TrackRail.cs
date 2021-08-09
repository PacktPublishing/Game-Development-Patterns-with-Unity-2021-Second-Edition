using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Ingredients.Track
{
    public class TrackRail : MonoBehaviour
    {
        [SerializeField] private int railNumber;

        void OnTriggerEnter(Collider other)
        {
            // TODO: Deprecated, the TrackManager will manage which track the player is on
            if (other.GetComponent<BikeController>())
                other.GetComponent<BikeController>().currentRail = railNumber;
        }
    }
}