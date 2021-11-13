using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using FPP.Scripts.Input.Commands;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Input
{
    public class InputHandler : MonoBehaviour
    {
        private bool _isLocked;
        private Invoker _invoker;
        private BikeController _bikeController;
        private Command _buttonA, _buttonD, _buttonSpace;

        private float _doubleTapTimeD;
        private float _doubleTapTimeA;

        [SerializeField] private float tapDelay = .5f;

        void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = FindObjectOfType<BikeController>();

            if (_bikeController)
            {
                _buttonA = new TurnLeft(_bikeController);
                _buttonD = new TurnRight(_bikeController);
                _buttonSpace = new Fire(_bikeController);
            }
            else
            {
                Debug.LogError("No BikeController found");
            }
        }

        void OnEnable()
        {
            // TODO: Toggling the input lock is causing unexpected when switching between top-level race states, replace with explicit input lock states
            RaceEventBus.Subscribe(RaceEventType.START, ToggleInputLock); 
            RaceEventBus.Subscribe(RaceEventType.FINISH, ToggleInputLock); 
            RaceEventBus.Subscribe(RaceEventType.RESTART, ToggleInputLock);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, ToggleInputLock);
            RaceEventBus.Unsubscribe(RaceEventType.FINISH, ToggleInputLock);
            RaceEventBus.Unsubscribe(RaceEventType.RESTART, ToggleInputLock);
        }

        private void ToggleInputLock()
        {
            _isLocked = !_isLocked;
        }

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                RaceEventBus.Publish(RaceEventType.PAUSE);

            if (UnityEngine.Input.GetKeyUp(KeyCode.Space))
                if (_isLocked)
                    _invoker.ExecuteCommand(_buttonSpace);

            if (UnityEngine.Input.GetKeyUp(KeyCode.A))
            {
                bool isDoubleTap = (Time.time < _doubleTapTimeA + tapDelay);
                _doubleTapTimeA = Time.time;

                if (_isLocked && !isDoubleTap)
                    _invoker.ExecuteCommand(_buttonA);
            }

            if (UnityEngine.Input.GetKeyUp(KeyCode.D))
            {
                bool isDoubleTap = (Time.time < _doubleTapTimeD + tapDelay);
                _doubleTapTimeD = Time.time;

                if (_isLocked && !isDoubleTap) 
                    _invoker.ExecuteCommand(_buttonD);
            }

            if (Debug.isDebugBuild)
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.F1))
                    RaceEventBus.Publish(RaceEventType.RESTART);

                if (UnityEngine.Input.GetKeyDown(KeyCode.F2))
                    ScreenCapture.CaptureScreenshot(Random.Range(0, 10000) + ".png", 4);

                if (UnityEngine.Input.GetKeyDown(KeyCode.F3))
                    _bikeController.TakeDamage(20, DamageType.Laser);
            }
        }
    }
}