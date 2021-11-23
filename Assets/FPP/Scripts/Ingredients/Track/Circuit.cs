using UnityEngine;
using System.Collections.Generic;

namespace FPP.Scripts.Ingredients.Track
{
    [CreateAssetMenu(fileName = "NewCircuit", menuName = "Ingredients/Circuit", order = 1)]
    public class Circuit : ScriptableObject
    {
        public string circuitName;

        public string circuitDescription;
        
        [Tooltip("Add tracks in expected track order")]
        public List<RaceTrack> raceTracks = new();
    }
}