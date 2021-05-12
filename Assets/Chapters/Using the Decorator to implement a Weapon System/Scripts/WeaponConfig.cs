using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewConfig", menuName = "Weapon/Config", order = 1)]
    public class WeaponConfig : ScriptableObject
    {
        public float range;
        public float duration;
        public float strength;
        public float cooldown;
        public string weaponName;
        public GameObject weaponPrefab;
        public string weaponDescription;
    }
}