using UnityEngine;

namespace FPP.Scripts.Weaponry
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

        public float range
        {
            get { return _decoratedWeapon.range + _attachment.range; }
        }

        public float strength
        {
            get { return _decoratedWeapon.strength + _attachment.strength; }
        }

        public float fireTime
        {
            get { return _decoratedWeapon.fireTime + _attachment.fireTime; }
        }

        public float cooldown
        {
            get { return _decoratedWeapon.cooldown + _attachment.cooldown; }
        }
        
        public Color BeamColor
        {
            get { return _decoratedWeapon.BeamColor; }
        }
    }
}