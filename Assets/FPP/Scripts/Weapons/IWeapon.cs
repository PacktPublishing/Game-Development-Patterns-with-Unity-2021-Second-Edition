using UnityEngine;

namespace Nerdtron.BladeRacer.Weaponary
{
    public interface IWeapon
    {
        float range { get; }
        float fireTime { get; }
        float strength { get; }
        float cooldown { get; }
        Color BeamColor { get; }
    }
}