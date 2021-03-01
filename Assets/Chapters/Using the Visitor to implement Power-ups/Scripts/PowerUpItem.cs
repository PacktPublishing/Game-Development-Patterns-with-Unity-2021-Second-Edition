using UnityEngine;

namespace Pattern.Visitor
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "ScriptableObjects/New PowerUp", order = 1)]
    public class PowerUpItem : ScriptableObject, IVisitor
    {
        public string title;
        public string description;
        public GameObject pickupPrefab;
        
        [Tooltip("Heal the shield fully")]
        public bool healShield;

        [Range(-50.0f, 50f)]
        [Tooltip("Turbo boost between -50/mph and 50/mph")]
        public float turboBoost;
    
        [Range(-25, 25)]
        [Tooltip("Weapon range boost between -25 unit and 25 units.")]
        public int weaponRangeBoost;

        [Range(-50f, 50f)]
        [Tooltip("Weapon strength boost between -50% and 50%.")]
        public float weaponStrengthBoost;

        public void Visit(BikeShield bikeShield)
        {
            if (healShield) bikeShield.strength = 100.0f; // percentage
        } 
    
        public void Visit(BikeWeapon bikeWeapon)
        {
            bikeWeapon.range += weaponRangeBoost;
            bikeWeapon.strength += bikeWeapon.strength * weaponStrengthBoost / 100; // TODO: Value needs to be rounded
        }
    
        public void Visit(BikeEngine bikeEngine)
        {
            if ((bikeEngine.turboBoost + turboBoost) < 0.0f)
            {
                bikeEngine.turboBoost = 0.0f;
            }
            else
            {
                bikeEngine.turboBoost += turboBoost;
            }
        }
    }
}