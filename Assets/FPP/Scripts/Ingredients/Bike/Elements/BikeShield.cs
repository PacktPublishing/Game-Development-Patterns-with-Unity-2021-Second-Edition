using UnityEngine;

public class BikeShield : MonoBehaviour, IBikeElement
{ 
    public int strength = 100;

    public float Damage(int damage)
    {
        strength -= damage;
        return strength;
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}