using FPP.Scripts.Controllers;

public interface IBikeState
{
    void Handle(BikeController controller);
}