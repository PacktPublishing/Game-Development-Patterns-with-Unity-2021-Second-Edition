using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewAttachment", menuName = "Weapon/Attachment", order = 2)]
    public class WeaponAttachment : ScriptableObject
    {
        [Range(0, 50)]
        public float range;
        
        [Range(0, 100)]
        public float strength;
        
        [Range(0, 3)]
        [Tooltip("Extend the firing duration")]
        public float duration;
        
        [Range(0, -10f)]
        [Tooltip("Reduce the time in takes to cooldown")]
        public float cooldown;
        
        public string attachmentName;
        public GameObject attachmentPrefab;
        public string attachmentDescription;
    }
}