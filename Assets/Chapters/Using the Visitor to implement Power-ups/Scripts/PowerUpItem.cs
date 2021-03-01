using UnityEngine;

namespace Pattern.Visitor
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "ScriptableObjects/New PowerUp", order = 1)]
    public class PowerUpItem : ScriptableObject, IVisitor
    {
        public string title;
        public string description;
        public GameObject pickupPrefab;
    
        [Range(-50f, 100f)]
        [Tooltip("Shield boost between -50% and 100%.")]
        public float shieldBoost;

        [Range(0.0f, 100f)]
        [Tooltip("Add to the turbo boost speed up to 100/mph.")]
        public float turboBoost;
    
        [Range(0, 25)]
        [Tooltip("Weapon range boost between 0 unit and 25 units.")]
        public int weaponRangeBoost;

        [Range(-50f, 100f)]
        [Tooltip("Weapon strength boost between -50% and 100%.")]
        public float weaponStrengthBoost;

        public void Visit(BikeShield bikeShield)
        {
            bikeShield.strength += bikeShield.strength * shieldBoost / 100;
        } 
    
        public void Visit(BikeWeapon bikeWeapon)
        {
            bikeWeapon.range += weaponRangeBoost;
            bikeWeapon.strength += bikeWeapon.strength * weaponStrengthBoost / 100;
        }
    
        public void Visit(BikeEngine bikeEngine)
        {
            bikeEngine.turboBoost += turboBoost;
        }
    }
}