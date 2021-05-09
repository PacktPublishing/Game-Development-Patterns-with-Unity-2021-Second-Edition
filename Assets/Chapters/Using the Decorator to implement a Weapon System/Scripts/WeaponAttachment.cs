using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "Weapon Attachment", menuName = "ScriptableObjects/New Weapon Attachment", order = 1)]
    public class WeaponAttachment : ScriptableObject
    {
        public float range;
        public float fireTime;
        public float strength;
        public float cooldown;
        public GameObject attachmentPrefab;
        public string attachmentDescription;
    }
}