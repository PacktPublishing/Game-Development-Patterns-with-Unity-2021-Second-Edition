using UnityEngine;

namespace FPP.Scripts.Weaponry
{
    [CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Ingredients/Weapon/Configuration", order = 1)]
    public class WeaponConfiguration : ScriptableObject
    {
        public float range;
        public float fireTime;
        public float strength;
        public float cooldown;
        public Color beamColor;
        public string weaponName;
        public GameObject weaponPrefab;
    }
}