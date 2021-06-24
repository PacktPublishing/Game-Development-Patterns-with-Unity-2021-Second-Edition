namespace Chapter.Decorator
{
    public interface IWeapon
    {
        float Rate { get; }
        float Range { get; }
        float Strength { get; }
        float Cooldown { get; }
    }
}