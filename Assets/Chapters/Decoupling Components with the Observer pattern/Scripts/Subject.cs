using UnityEngine;
using System.Collections;

namespace Chapter.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private ArrayList observers = new ArrayList();

        public void Attach(Observer o)
        {
            observers.Add(o);
        }

        public void Detach(Observer o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Notify(this);
            }
        }
    }
}