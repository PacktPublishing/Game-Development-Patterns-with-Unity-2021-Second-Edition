using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewAttachment", menuName = "Weapon/Attachment", order = 2)]
    public class WeaponAttachment : ScriptableObject, IWeapon
    {
        [Range(0, 50)]
        [SerializeField] float range;
        
        [Range(0, 100)]
        [SerializeField] public float strength;
        
        [Range(0, 3)]
        [Tooltip("Extend the firing duration")]
        [SerializeField] public float duration;
        
        [Range(0, -10f)]
        [Tooltip("Reduce the time in takes to cooldown")]
        [SerializeField] public float cooldown;
        
        public string attachmentName;
        public GameObject attachmentPrefab;
        public string attachmentDescription;

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