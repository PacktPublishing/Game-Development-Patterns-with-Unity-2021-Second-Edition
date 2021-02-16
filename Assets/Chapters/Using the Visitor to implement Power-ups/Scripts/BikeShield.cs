using UnityEngine;

namespace Pattern.Visitor
{
    public class BikeShield : MonoBehaviour, IBikeElement
    { 
        public float strength = 100.0f;

        public float Damage(float damage)
        {
            strength -= damage;
            return strength;
        }
    
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}