using UnityEngine;

namespace FPP.Scripts.Weaponry
{
    public class Weapon : IWeapon
    {
        public float range
        {
            get { return _config.range; }
        }

        public float fireTime
        {
            get { return _config.fireTime; }
        }

        public float strength
        {
            get { return _config.strength; }
        }

        public float cooldown
        {
            get { return _config.cooldown; }
        }

        public Color BeamColor
        {
            get { return _config.beamColor;  }
        }

        private readonly WeaponConfiguration _config;

        public Weapon(WeaponConfiguration weaponConfig)
        {
            _config = weaponConfig;
        }
    }
}