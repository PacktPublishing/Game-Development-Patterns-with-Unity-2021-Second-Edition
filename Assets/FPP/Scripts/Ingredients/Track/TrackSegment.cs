using UnityEngine;
using FPP.Scripts.Controllers;

namespace FPP.Scripts.Ingredients.Track
{
    public class TrackSegment : MonoBehaviour
    {
        public TrackController trackController;

        private void OnDestroy()
        {
            if (trackController)
                trackController.LoadNextSegment();
        }
    }
}