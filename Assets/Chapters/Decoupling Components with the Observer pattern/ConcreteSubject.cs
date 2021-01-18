public class ConcreteSubject : Subject
{
    private string state;

    public string GetState()
    {
        return state;
    }

    public void SetState(string newState)
    {
        state = newState;
        Notify();
    }
}