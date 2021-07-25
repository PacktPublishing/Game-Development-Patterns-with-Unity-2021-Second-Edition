using UnityEngine;
using System.Collections;

namespace Chapter.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly 
            ArrayList _observers = new ArrayList();

        protected void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        protected void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        protected void NotifyObservers()
        {
            foreach (Observer observer in _observers)
            {
                observer.Notify(this);
            }
        }
    }
}