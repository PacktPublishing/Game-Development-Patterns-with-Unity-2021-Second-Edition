using UnityEngine;

namespace Chapter.Observer
{
    public class BikeController : Subject
    {
        public bool IsTurboOn { get; private set; }
        public float CurrentHealth { get { return _health; } }
        
        private float _health = 100.0f;
        private HUDController _hudController;
        
        void Awake()
        {
            InitComponents();
            AttachObservers();
        }

        void Start()
        {
            Damage(6.0f);
        }

        private void InitComponents()
        {
            _hudController = gameObject.AddComponent<HUDController>();
        }

        private void AttachObservers()
        {
            Attach(_hudController);
        }

        public void ToggleTurbo()
        {
            IsTurboOn = !IsTurboOn;
            //Notify();
        }
        
        public void Damage(float amount)
        {
            _health -= amount;
            Notify();
        }
    }
}