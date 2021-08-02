using UnityEngine;

namespace FPP.Scripts.Ingredients.Bike
{
    [CreateAssetMenu(fileName = "NewBikeConfiguration", menuName = "Ingredients/Bike Configuration", order = 2)]
    public class BikeConfiguration : ScriptableObject
    {
        public string bikeName;
        public GameObject bikePrefab;

        [Tooltip("The default speed of the bike")]
        public int defaultSpeed;

        [Tooltip("The max speed of the bike")] public int maxSpeed;

        [Range(0.0f, 100.0f)] [Tooltip("Turbo speed boost in percentage")]
        public int turboBoost;

        [Range(0.0f, 60.0f)] [Tooltip("Turbo boost duration in seconds")]
        public int turboDuration;

        [Range(0.0f, 60.0f)] [Tooltip("Amounts of seconds it takes to reach top speed")]
        public int secondsToTopSpeed;
    }
}