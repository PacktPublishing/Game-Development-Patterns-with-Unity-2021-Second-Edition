using UnityEngine;

namespace Pattern.Visitor
{
    public class BikeWeapon : MonoBehaviour, IBikeElement
    {
        // Units
        public int range = 5; 
        public int maxRange = 25;
        
        // Percentage
        public float strength = 25;
        public float maxStrength = 50;
        
        public void Fire()
        {
            Debug.Log("Weapon fired!");
        }
    
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        void OnGUI() 
        {
            GUI.color = Color.green;
            
            GUI.Label(
                new Rect(125, 40, 200, 20), 
                "Weapon Range: " + range);
            
            GUI.Label(
                new Rect(125, 60, 200, 20), 
                "Weapon Strength: " + strength);
        }
    }
}