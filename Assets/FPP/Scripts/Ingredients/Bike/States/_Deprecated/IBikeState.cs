using FPP.Scripts.Ingredients.Bike;

public interface IBikeState
{
    void Handle(BikeController controller);
}