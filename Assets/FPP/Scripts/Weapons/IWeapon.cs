using UnityEngine;

namespace FPP.Scripts.Weapons
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