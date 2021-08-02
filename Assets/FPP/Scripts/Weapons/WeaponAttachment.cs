using UnityEngine;

namespace Nerdtron.BladeRacer.Weaponary
{
    [CreateAssetMenu(fileName = "NewWeaponAttachment", menuName = "Ingredients/Weapon/Attachment", order = 2)]
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