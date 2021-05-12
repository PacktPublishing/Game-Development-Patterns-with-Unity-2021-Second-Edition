namespace Chapter.Decorator
{
    public class Weapon : IWeapon
    {
        public float Range
        {
            get { return _config.range; }
        }

        public float Duration
        {
            get { return _config.duration; }
        }

        public float Strength
        {
            get { return _config.strength; }
        }

        public float Cooldown
        {
            get { return _config.cooldown; }
        }
        
        private readonly WeaponConfig _config;

        public Weapon(WeaponConfig weaponConfig)
        {
            _config = weaponConfig;
        }
    }
}