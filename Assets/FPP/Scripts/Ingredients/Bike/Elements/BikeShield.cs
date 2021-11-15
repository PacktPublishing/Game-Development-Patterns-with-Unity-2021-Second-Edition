using UnityEngine;

public class BikeShield : MonoBehaviour, IBikeElement
{
    public int currentStrength;
    private const int DefaultStrength = 100; // Percentage points

    void Awake()
    {
        currentStrength = DefaultStrength;
    }

    public float TakeDamage(int damage)
    {
        currentStrength -= damage;
        return currentStrength;
    }

    public void ResetShieldStrength()
    {
        currentStrength = DefaultStrength;
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}