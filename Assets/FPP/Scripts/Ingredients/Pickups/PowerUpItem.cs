using UnityEngine;

namespace FPP.Scripts.Ingredients.Pickups
{
    [CreateAssetMenu(fileName = "NewPowerUp", menuName = "Ingredients/PowerUp", order = 1)]
    public class PowerUpItem : ScriptableObject, IVisitor
    {
        public string title;
        public Color pickupColor;
        public string description;

        [Range(-50f, 100f)] [Tooltip("Shield boost between -50% and 100%.")]
        public int shieldBoost;

        [Range(-50f, 100f)] [Tooltip("Speed boost between -50% and 100%.")]
        public float speedBoost;

        public void Visit(BikeShield bikeShield)
        {
            bikeShield.strength += shieldBoost;
        }
    }
}