using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

public class SegmentMarker : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BikeController>()) 
            Destroy(transform.parent.gameObject);
    }
}