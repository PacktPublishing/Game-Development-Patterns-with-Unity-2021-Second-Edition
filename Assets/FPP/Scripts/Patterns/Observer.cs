using UnityEngine;

namespace FPP.Scripts.Patterns
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void Notify(Subject subject);
    }
}