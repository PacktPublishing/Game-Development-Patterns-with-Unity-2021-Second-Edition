using UnityEngine;

namespace Chapter.SpatialPartition
{
    public class SegmentMarker : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<BikeController>())
                Destroy(transform.parent.gameObject);
        }
    }
}