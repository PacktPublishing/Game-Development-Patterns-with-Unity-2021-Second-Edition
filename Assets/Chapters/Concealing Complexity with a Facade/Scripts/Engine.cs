using UnityEngine;

namespace Chapter.Facade
{
    public class Engine : MonoBehaviour
    {
        public float burnRate = 1.0f;
        public float fuelAmount = 100.0f;
        public float tempRate = 5.0f;
        public float currentTemp;
        public float minTemp = 50.0f;
        public float maxTemp = 85.0f;
        public float turboDuration = 3.0f;

        private bool _isEngineOn;
        private FuelPump _fuelPump;
        private TurboCharger _turboCharger;
        private CoolingSystem _coolingSystem;
        
        private void Awake()
        {
            _fuelPump = gameObject.AddComponent<FuelPump>();
            _turboCharger = gameObject.AddComponent<TurboCharger>();
            _coolingSystem = gameObject.AddComponent<CoolingSystem>();
        }

        private void Start()
        {
            _fuelPump.engine = this;
            _turboCharger.engine = this;
            _coolingSystem.engine = this;
        }
        
        public void TurnOn()
        {
            _isEngineOn = true;
            StartCoroutine(_fuelPump.burnFuel);
            StartCoroutine(_coolingSystem.coolEngine);
        }

        public void TurnOff()
        {
            _isEngineOn = false;
            StopCoroutine(_fuelPump.burnFuel);
            StopCoroutine(_coolingSystem.coolEngine);
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn) 
                _turboCharger.ToggleTurbo(_coolingSystem);
        }
    }
}

