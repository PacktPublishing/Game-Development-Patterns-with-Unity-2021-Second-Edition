using UnityEngine;
using System.Collections.Generic;

namespace Chapter.SpatialPartition
{
    [CreateAssetMenu(fileName = "Track", menuName = "ScriptableObjects/New Track", order = 2)]
    public class Track : ScriptableObject
    {
        public float segmentSize;
        public List<GameObject> segments = new List<GameObject>();
    }
}