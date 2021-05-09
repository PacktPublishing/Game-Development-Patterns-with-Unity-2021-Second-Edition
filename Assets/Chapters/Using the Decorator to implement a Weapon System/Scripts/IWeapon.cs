namespace Chapter.Decorator
{
    public interface IWeapon
    {
        float range { get; }
        float fireTime { get; }
        float strength { get; }
        float cooldown { get; }
    }
}