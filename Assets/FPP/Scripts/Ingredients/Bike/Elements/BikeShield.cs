using UnityEngine;

namespace FPP.Scripts.Ingredients.Bike.Elements
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public int currentStrength;
        public int maxStrength = 100; // Percentage

        void Awake()
        {
            currentStrength = maxStrength;
        }

        public float TakeDamage(int damage)
        {
            currentStrength -= damage;
            return currentStrength;
        }

        public void ResetShieldStrength()
        {
            currentStrength = maxStrength;
        }
    
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}