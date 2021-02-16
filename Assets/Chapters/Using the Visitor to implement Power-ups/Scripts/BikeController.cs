using UnityEngine;
using System.Collections.Generic;

namespace Pattern.Visitor
{
    public class BikeController : MonoBehaviour, IBikeElement
    {
        private List<IBikeElement> elements = new List<IBikeElement>();
        
        void Start()
        {
           elements.Add(gameObject.AddComponent<BikeShield>());
           elements.Add(gameObject.AddComponent<BikeWeapon>());
        }
        
        public void Accept(IVisitor visitor)
        {
            foreach (IBikeElement element in elements)
            {
                element.Accept(visitor);
            }
            //visitor.Visit(this);
        }
    }
}
