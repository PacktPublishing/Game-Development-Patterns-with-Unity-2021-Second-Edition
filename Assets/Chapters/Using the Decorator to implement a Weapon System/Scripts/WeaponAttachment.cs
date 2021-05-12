using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewAttachment", menuName = "Weapon/Attachment", order = 2)]
    public class WeaponAttachment : ScriptableObject
    {
        public float range;
        public float duration;
        public float strength;
        public float cooldown;
        public string attachmentName;
        public GameObject attachmentPrefab;
        public string attachmentDescription;
    }
}