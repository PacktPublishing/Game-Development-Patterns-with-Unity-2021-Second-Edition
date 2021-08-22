using UnityEngine;

namespace FPP.Scripts.Ingredients.Bike.Engine
{
    public class BikeEngine : MonoBehaviour
    {
        [Header("Fuel Pump")] 
        public float burnRate = 1.0f;
        public float fuelAmount = 100.0f;

        [Header("Cooling System")] 
        public float minTemp = 50.0f;
        public float maxTemp = 65.0f;
        public float tempRate = 5.0f;
        public float currentTemp;

        public int CurrentSpeed { get; set; }
        public bool IsEngineOn { get; private set; }
        public BikeController BikeController { get; set; }
        
        // TODO: Refactor this properties, because they not to safe to call directly
        // TODO: Consider using the visitor pattern to update engine's properties
        public bool IsTurboOn { get { return _turboCharger.IsTurboOn; } }
        public int DefaultSpeed { get { return BikeController.bikeBlueprint.defaultSpeed; } }
        public int TurboBoostAmount { get { return BikeController.bikeBlueprint.turboBoost; } }
        public float TurboDuration { get { return BikeController.bikeBlueprint.turboDuration; } }

        private FuelPump _fuelPump;
        private TurboCharger _turboCharger;
        private CoolingSystem _coolingSystem;

        void Awake()
        {
            _fuelPump = gameObject.AddComponent<FuelPump>();
            _turboCharger = gameObject.AddComponent<TurboCharger>();
            _coolingSystem = gameObject.AddComponent<CoolingSystem>();
        }

        void Start()
        {
            _fuelPump.BikeEngine = this;
            _turboCharger.BikeEngine = this;
            _coolingSystem.BikeEngine = this;
        }

        public void TurnOn()
        {
            IsEngineOn = true;
            CurrentSpeed = DefaultSpeed; // TODO: Between the bike controller and the engine, they should be a gear system
            
            StartCoroutine(_fuelPump.burnFuel);
            StartCoroutine(_coolingSystem.coolEngine);
        }

        public void TurnOff()
        {
            IsEngineOn = false;
            _coolingSystem.ResetTemperature();
            CurrentSpeed = 0;
            
            StopCoroutine(_fuelPump.burnFuel);
            StopCoroutine(_coolingSystem.coolEngine);
        }

        public void ToggleTurbo()
        {
            if (IsEngineOn)
                _turboCharger.ToggleTurbo(_coolingSystem);
        }
    }
}