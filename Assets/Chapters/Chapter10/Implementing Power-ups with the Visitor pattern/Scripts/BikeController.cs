using UnityEngine;
using System.Collections.Generic;

namespace Pattern.Visitor
{
    public class BikeController : MonoBehaviour, IBikeElement
    {
        private List<IBikeElement> _bikeElements = 
            new List<IBikeElement>();
        
        void Start()
        {
            _bikeElements.Add(
                gameObject.AddComponent<BikeShield>());
            _bikeElements.Add(
                gameObject.AddComponent<BikeWeapon>());
            _bikeElements.Add(
                gameObject.AddComponent<BikeEngine>());
        }
        
        public void Accept(IVisitor visitor)
        {
            foreach (IBikeElement element in _bikeElements)
            {
                element.Accept(visitor);
            }
        }
    }
}