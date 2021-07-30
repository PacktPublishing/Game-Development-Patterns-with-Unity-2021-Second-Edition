using UnityEngine;

namespace FPP.Scripts.Ingredients.Bike.Engine
{
    public class BikeEngine : MonoBehaviour
    {
        [Header("Fuel Pump")] public float burnRate = 1.0f;
        public float fuelAmount = 100.0f;

        [Header("Turbo Charger")] public float turboDuration = 2.0f;

        [Header("Cooling System")] public float minTemp = 50.0f;
        public float maxTemp = 65.0f;
        public float tempRate = 5.0f;
        public float currentTemp;

        private bool _isEngineOn;
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
            _isEngineOn = true;
            StartCoroutine(_fuelPump.burnFuel);
            StartCoroutine(_coolingSystem.coolEngine);
        }

        public void TurnOff()
        {
            _isEngineOn = false;
            _coolingSystem.ResetTemperature();
            StopCoroutine(_fuelPump.burnFuel);
            StopCoroutine(_coolingSystem.coolEngine);
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn)
                _turboCharger.ToggleTurbo(_coolingSystem);
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(
                new Rect(10, 0, 500, 20),
                "Engine Running: " + _isEngineOn);
        }
    }
}