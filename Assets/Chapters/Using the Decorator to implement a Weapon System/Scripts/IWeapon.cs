namespace Chapter.Decorator
{
    public interface IWeapon
    {
        float Range { get; }
        float Duration { get; }
        float Strength { get; }
        float Cooldown { get; }
    }
}