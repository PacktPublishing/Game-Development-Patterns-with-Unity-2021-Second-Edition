using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Interfaces;

namespace FPP.Scripts.Ingredients.Bike
{
    [CreateAssetMenu(fileName = "NewBikeBlueprint", menuName = "Ingredients/Bike/Blueprint", order = 2)]
    public class BikeBlueprint : ScriptableObject, IInventoryItem
    {
        public float itemValue;
        public string blueprintName;
        
        [Header("Assets")]
        public GameObject bikePrefab;
        public Texture blueprintTexture;
        
        [Header("Speed")]
        public int defaultSpeed;
        public int maxSpeed;
        [Range(0.0f, 60.0f)] 
        [Tooltip("Amounts of seconds it takes to reach top speed")]
        public int secondsToTopSpeed;

        [Header("Turbo")]
        [Range(0.0f, 100.0f)] 
        [Tooltip("Turbo speed boost in percentage")]
        public int turboBoost;
        
        [Range(0.0f, 60.0f)] 
        [Tooltip("Turbo boost duration in seconds")]
        public int turboDuration;

        public ItemType GetItemType()
        {
            return ItemType.Blueprint;
        }

        public float GetItemValue()
        {
            return itemValue;
        }
    }
}