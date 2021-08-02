using UnityEngine;
using FPP.Scripts.Controllers;

public class Segment : MonoBehaviour
{
    public TrackController trackController;
    
    private void OnDestroy()
    {
        if (trackController) 
            trackController.LoadNextSegment();
    }
}