using System.Collections;

public abstract class Subject
{
    private ArrayList observers = new ArrayList();

    public void Attach(IObserver o)
    {
        observers.Add(o);
    }

    public void Detach(IObserver o)
    {
        observers.Remove(o);
    }

    public void Notify()
    {
        foreach (IObserver o in observers)
        {
            o.Update();
        }
    }
}