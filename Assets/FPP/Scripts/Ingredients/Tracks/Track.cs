using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewTrack", menuName = "Ingredients/Track", order = 1)]
public class Track : ScriptableObject
{
    [Tooltip("The expected length of segments")] 
    public float segmentLength;
    
    [Tooltip("Add segments in expected loading order")] 
    public List<GameObject> segments = new List<GameObject>();
}