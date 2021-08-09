using FPP.Scripts.Enums;

namespace FPP.Scripts.Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(float amount, DamageType type);
    }
}