using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewConfig", menuName = "Weapon/Config", order = 1)]
    public class WeaponConfig : ScriptableObject, IWeapon
    {
        [Range(0, 50)]
        [SerializeField] private float range;
        
        [Range(0, 100)]
        [SerializeField] private float strength;
        
        [Range(0, 3)]
        [Tooltip("Duration of the laser beam in seconds")]
        [SerializeField] private float duration;
        
        [Range(0, 10f)]
        [Tooltip("The amount of seconds to cooldown the weapon")]
        [SerializeField] private float cooldown;
        
        public string weaponName;
        public GameObject weaponPrefab;
        public string weaponDescription;
        
        public float Range
        {
            get { return range; }
        }

        public float Duration
        {
            get { return duration;  }
        }

        public float Strength
        {
            get { return strength;  }
        }

        public float Cooldown
        {
            get { return cooldown; }
        }
    }
}