using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "Weapon Config", menuName = "ScriptableObjects/New Weapon Config", order = 1)]
    public class WeaponConfig : ScriptableObject
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