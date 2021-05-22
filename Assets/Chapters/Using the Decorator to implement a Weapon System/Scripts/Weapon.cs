namespace Chapter.Decorator
{
    public class Weapon : IWeapon
    { 
        public float Range
        {
            get { return _config.Range; }
        }

        public float Duration
        {
            get { return _config.Duration; }
        }

        public float Strength
        {
            get { return _config.Strength; }
        }

        public float Cooldown
        {
            get { return _config.Cooldown; }
        }
        
        private readonly WeaponConfig _config;

        public Weapon(WeaponConfig weaponConfig)
        {
            _config = weaponConfig;
        }
    }
}