using UnityEngine;

namespace Pattern.Visitor
{
    public class BikeShield : MonoBehaviour, IVisitable
    { 
        public float strength = 100.0f;

        public void Damage(float damage)
        {
            strength -= damage;
        }
    
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}