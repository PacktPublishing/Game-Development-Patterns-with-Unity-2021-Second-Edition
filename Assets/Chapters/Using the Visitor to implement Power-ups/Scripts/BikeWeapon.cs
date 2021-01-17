using UnityEngine;

namespace Pattern.Visitor
{
    public class BikeWeapon : MonoBehaviour, IVisitable
    {
        public int range = 5; // Units
        public float strength = 25; // Percentage 

        public void Fire()
        {
            Debug.Log("Weapon fired!");
        }
    
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}