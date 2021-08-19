using UnityEngine;

namespace FPP.Scripts.Weaponry
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