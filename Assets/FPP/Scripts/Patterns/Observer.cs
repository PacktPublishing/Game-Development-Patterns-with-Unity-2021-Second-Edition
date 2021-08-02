using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void Notify(Subject subject);
}
