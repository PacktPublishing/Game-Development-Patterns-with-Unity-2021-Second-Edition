using UnityEngine;
using System.Collections;

namespace FPP.Scripts.Patterns
{
    public abstract class Subject : MonoBehaviour
    {
        private ArrayList observers = new ArrayList();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                if (observer)
                    observer.Notify(this);
            }
        }
    }
}