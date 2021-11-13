using UnityEngine;

namespace FPP.Scripts.Ingredients.Track
{
    public class BaseTrack : MonoBehaviour
    {
        public GameObject bike;
        public GameObject bikeSpawnPoint;
        
        public void ResetBikeToSpawnPoint() // TODO: The bike spawner should handle the process of spawning a "ghost bike" during the replay sequence
        {
            bike.transform.position = bikeSpawnPoint.transform.position;
        }
    }
}