using UnityEngine;

namespace Chapter.Facade
{
    public class EngineFacade : MonoBehaviour
    {
        public delegate void TurnedOn();
        public static event TurnedOn OnTurnOn;
        
        public delegate void TurnedOff();
        public static event TurnedOff OnTurnOff;
        
        public delegate void TogglingTurbo();
        public static event TogglingTurbo OnTogglingTurbo;

        private bool _isEngineOn;
        private bool _isEngineDamaged;
        private FuelPump _fuelPump;
        private TurboCharger _turboCharger;
        private CoolingSystem _coolingSystem;
        
        // Fuel
        [SerializeField] private float fuelAmount = 100.0f;

        // Cooling
        [SerializeField] private float minTemperature = 10.0f;
        [SerializeField] private float maxTemperature = 85.0f;
        
        // Turbo
        [SerializeField] private float turboBoostAmount = 0.25f;
        [SerializeField] private float turboBoostDuration = 30.0f;
        
        private void Awake()
        {
            _fuelPump = gameObject.AddComponent<FuelPump>();
            _turboCharger = gameObject.AddComponent<TurboCharger>();
            _coolingSystem = gameObject.AddComponent<CoolingSystem>();
        }

        private void Start()
        {
            _fuelPump.AddFuel(fuelAmount);
            _turboCharger.boostAmount = turboBoostAmount;
            _turboCharger.boostDuration = turboBoostDuration;
            _coolingSystem.minTemperature = minTemperature;
            _coolingSystem.maxTemperature = maxTemperature;
        }

        private void OnEnable()
        {
            FuelPump.OnTankEmpty += StopEngine;
        }

        private void OnDisable()
        {
            FuelPump.OnTankEmpty -= StopEngine;
        }

        public void TurnOn()
        {
            if (!_isEngineOn && !_isEngineDamaged)
            {
                _isEngineOn = true;
                OnTurnOn.Invoke();
            }
        }

        public void TurnOff()
        {
            _isEngineOn = false;
            OnTurnOff.Invoke();
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn && !_isEngineDamaged)
            {
                OnTogglingTurbo.Invoke();
            }
            else
            {
                Debug.Log("Engine is off or damaged, cannot turn on turbo charge");
            }
        }

        private void DestroyEngine()
        {
            _isEngineDamaged = true;
            Debug.Log("Engine destroyed because of overheating");    
        }
        
        private void StopEngine()
        {
            _isEngineDamaged = true;
            Debug.Log("Engine stopped because of lack of fuel");
        }
    }
}

