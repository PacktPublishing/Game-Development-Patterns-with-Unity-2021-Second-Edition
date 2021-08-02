using FPP.Scripts.Controllers;

public class BikeStateContext
{
    private IBikeState _currentState;
    private BikeController _bikeController;

    public BikeStateContext(BikeController bikeController)
    {
        _bikeController = bikeController;
    }
    
    public void SetState(IBikeState bikeState)
    {
        _currentState = bikeState;
    }

    public void Transition()
    {
        _currentState.Handle(_bikeController);
    }
    
    public void Transition(IBikeState bikeState)
    {
        _currentState = bikeState;
        _currentState.Handle(_bikeController);
    }
}