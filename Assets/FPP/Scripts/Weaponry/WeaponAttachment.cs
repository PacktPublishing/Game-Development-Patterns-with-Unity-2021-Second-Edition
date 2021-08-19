using UnityEngine;

namespace FPP.Scripts.Weaponry
{
    [CreateAssetMenu(fileName = "NewWeaponAttachment", menuName = "Ingredients/Weapon/Attachment", order = 2)]
    public class WeaponAttachment : ScriptableObject
    {
        [Header("Attributes")] public float range;
        public float fireTime;
        public float strength;
        public float cooldown;

        public decimal itemPrice;
        public GameObject attachmentPrefab;
        public string attachmentDescription;
    }
}