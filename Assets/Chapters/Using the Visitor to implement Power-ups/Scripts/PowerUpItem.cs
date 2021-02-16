using UnityEngine;
using System.Collections;

namespace Pattern.Visitor
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "ScriptableObjects/New PowerUp", order = 1)]
    public class PowerUpItem : ScriptableObject, IVisitor
    {
        public string title;
        public string description;
    
        [Range(-50f, 100f)]
        [Tooltip("Shield boost between -50% and 100%.")]
        public float shieldBoost;

        [Range(-50f, 100f)]
        [Tooltip("Speed boost between -50% and 100%.")]
        public float speedBoost;
    
        [Range(0, 25)]
        [Tooltip("Weapon range boost between 1 unit and 25 units.")]
        public int weaponRangeBoost;

        [Range(-50f, 100f)]
        [Tooltip("Weapon strength boost between -50% and 100%.")]
        public float weaponStrengthBoost;

        public void Visit(BikeShield bikeShield)
        {
            bikeShield.strength += bikeShield.strength * shieldBoost / 100;
            
            Debug.Log("Shield Strenght: " + bikeShield.strength);
        } 
    
        public void Visit(BikeWeapon bikeWeapon)
        {
            bikeWeapon.range += weaponRangeBoost;
            bikeWeapon.strength += bikeWeapon.strength * weaponStrengthBoost / 100;
            
            Debug.Log("Weapon Range: " + bikeWeapon.range);
            Debug.Log("Weapon Strenght: " + bikeWeapon.strength);
        }
    
        public void Visit(BikeEngine bikeEngine)
        {
            bikeEngine.NormalSpeed += bikeEngine.NormalSpeed * speedBoost / 100;

            Debug.Log("Default Speed: " + bikeEngine.NormalSpeed);
            Debug.Log("Turbo Speed: " + bikeEngine.TurboSpeed);
        }
    }
}