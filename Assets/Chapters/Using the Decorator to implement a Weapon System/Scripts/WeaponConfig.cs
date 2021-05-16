using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewConfig", menuName = "Weapon/Config", order = 1)]
    public class WeaponConfig : ScriptableObject
    {
        [Range(0, 50)]
        public float range;
        
        [Range(0, 100)]
        public float strength;
        
        [Range(0, 3)]
        [Tooltip("Duration of the laser beam in seconds")]
        public float duration;
        
        [Range(0, 10f)]
        [Tooltip("The amount of seconds to cooldown the weapon")]
        public float cooldown;
        
        public string weaponName;
        public GameObject weaponPrefab;
        public string weaponDescription;
    }
}