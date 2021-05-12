namespace Chapter.Decorator
{
    public class WeaponDecorator : IWeapon
    {
        private readonly IWeapon _decoratedWeapon;
        private readonly WeaponAttachment _attachment;

        public WeaponDecorator(IWeapon weapon, WeaponAttachment attachment)
        {
            _attachment = attachment;
            _decoratedWeapon = weapon;
        }

        public float Range
        {
            get { return _decoratedWeapon.Range + _attachment.range; }
        }

        public float Strength
        {
            get { return _decoratedWeapon.Strength + _attachment.strength; }
        }

        public float Duration
        {
            get { return _decoratedWeapon.Duration + _attachment.duration; }
        }

        public float Cooldown
        {
            get { return _decoratedWeapon.Cooldown + _attachment.cooldown; }
        }
    }
}