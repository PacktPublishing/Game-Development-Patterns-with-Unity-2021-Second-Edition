using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Ingredients.Track
{
    public class TrackSegmentMarker : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<BikeController>())
                Destroy(transform.parent.gameObject);
        }
    }
}