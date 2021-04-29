using UnityEngine;
using System.Collections;

namespace Chapter.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly ArrayList _observers = new ();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (Observer observer in _observers)
            {
                observer.Notify(this);
            }
        }
    }
}