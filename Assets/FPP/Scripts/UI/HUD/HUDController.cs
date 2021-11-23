using UnityEngine;
using UnityEngine.UI;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.UI.HUD
{ 
    public class HUDController : Observer
    {
        [SerializeField] private Text statusField;
        
        [Header("Bike")]
        [SerializeField] private Text speedField;
        [SerializeField] private Text shieldField;
       
        [Header("Warning")]
        [SerializeField] private Text warningField;
        [SerializeField] private float shieldWarningThreshold;
        
        [Header("Timer")]
        [SerializeField] private GameObject raceTimer;
        [SerializeField] private GameObject countdownTimer;
        
        [Header("Menu")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject restartMenu;
        
        [Header("Engine")]
        [SerializeField] private Text fuel;
        [SerializeField] private Text temperature;
        
        private BikeController _bikeController;

        void Update()
        {
            if (_bikeController)
            {
                speedField.text = _bikeController.CurrentSpeed.ToString();
                
                if (_bikeController.BikeEngine)
                {
                    fuel.text = _bikeController.BikeEngine.fuelAmount.ToString();
                    temperature.text = _bikeController.BikeEngine.currentTemp.ToString();
                }
            }
        }

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, StartTimer);
            RaceEventBus.Subscribe(RaceEventType.PAUSE, DisplayPauseMenu);
            RaceEventBus.Subscribe(RaceEventType.REPLAY, DisplayReplayMenu);
            RaceEventBus.Subscribe(RaceEventType.FINISH, DisplayRestartMenu);
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, DisplayCountdownTimer);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, StartTimer);
            RaceEventBus.Unsubscribe(RaceEventType.PAUSE, DisplayPauseMenu);
            RaceEventBus.Unsubscribe(RaceEventType.REPLAY, DisplayReplayMenu);
            RaceEventBus.Unsubscribe(RaceEventType.FINISH, DisplayRestartMenu);
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, DisplayCountdownTimer);
        }

        private void StartTimer()
        {
            raceTimer.GetComponent<RaceTimer>().StartTimer();
        }

        private void DisplayReplayMenu() // TODO: Hide timer during replay
        {
            restartMenu.SetActive(false);
            statusField.text = "REPLAY";
        }

        private void DisplayPauseMenu()
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            raceTimer.GetComponent<RaceTimer>().PauseTimer();
        }

        private void DisplayCountdownTimer()
        {
            if (countdownTimer)
            {
                countdownTimer.SetActive(true);
                countdownTimer.GetComponent<CountdownTimer>().StartTimer();
            }
        }

        private void DisplayRestartMenu()
        {
            statusField.text = "FINISH";

            raceTimer.GetComponent<RaceTimer>().StopTimer();
            restartMenu.SetActive(true);
        }

        private void DisplayWarning(string message)
        {
            warningField.text = message;
        }

        private void UpdateShieldHealthMeter(float healthAmount)
        {
            // TODO: Removed hard coded strings and manage with localization system
            shieldField.text = healthAmount.ToString();

            if (healthAmount < shieldWarningThreshold)
                DisplayWarning("Warning: Shield below " + shieldWarningThreshold + "%");

            if (healthAmount <= 0.0f)
                statusField.text = "GAME OVER";
        }
        
        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController = subject.GetComponent<BikeController>();
            
            if (_bikeController.BikeShield)
                UpdateShieldHealthMeter(_bikeController.BikeShield.currentStrength);
        }

        public void RestartRace()
        {
            RaceEventBus.Publish(RaceEventType.RESTART);
        }
        
        public void StartReplay()
        {
            RaceEventBus.Publish(RaceEventType.REPLAY);
        }

        public void EndRace()
        {
            RaceEventBus.Publish(RaceEventType.END);
        }
    }
}