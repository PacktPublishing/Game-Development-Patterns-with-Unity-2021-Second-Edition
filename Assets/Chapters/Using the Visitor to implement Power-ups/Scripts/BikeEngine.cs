using UnityEngine;

namespace Pattern.Visitor
{
    public class BikeEngine : MonoBehaviour, IBikeElement
    {
        private bool _isTurboOn;
    
        // Default settings
        private float _normalSpeed = 500.0f; // 500 kmh
        private float _turboSpeed = 700.0f; // 700 kmh
    
        public float NormalSpeed
        {
            get => _normalSpeed;
            set => _normalSpeed = value;
        }
    
        public float TurboSpeed
        {
            get => _turboSpeed;
            set => _turboSpeed = value;
        }

        public float CurrentSpeed
        {
            get
            {
                if (_isTurboOn) return _turboSpeed;
                return _normalSpeed;
            }
        }

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
        }
    
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}