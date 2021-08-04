using UnityEngine;
using UnityEngine.UI;
using FPP.Scripts.UI;
using FPP.Scripts.Enums;
using System.Collections;
using FPP.Scripts.Patterns;

namespace FPP.Scripts.Controllers
{ 
    public class HUDController : Observer
    {
        [SerializeField] private Text speedField;
        [SerializeField] private Text statusField;
        [SerializeField] private Text shieldField;
        [SerializeField] private Text warningField;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject raceTimer;
        [SerializeField] private GameObject restartMenu;
        [SerializeField] private GameObject countdownTimer;
        [SerializeField] private float shieldWarningThreshold;

        private int newSpeed;

        private void Start()
        {
            StartCoroutine(UpdateSpeedMeter());
        }

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, StartTimer);
            RaceEventBus.Subscribe(RaceEventType.PAUSE, DisplayPauseMenu);
            RaceEventBus.Subscribe(RaceEventType.FINISH, DisplayRestartMenu);
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, DisplayCountdownTimer);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, StartTimer);
            RaceEventBus.Unsubscribe(RaceEventType.PAUSE, DisplayPauseMenu);
            RaceEventBus.Unsubscribe(RaceEventType.FINISH, DisplayRestartMenu);
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, DisplayCountdownTimer);
        }

        private void StartTimer()
        {
            raceTimer.GetComponent<RaceTimer>().StartTimer();
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

        private void UpdateShieldMeter(float level)
        {
            // TODO: Removed hard coded strings and manage with localization system
            shieldField.text = level.ToString();

            if (level < shieldWarningThreshold)
                DisplayWarning("Warning: Shield below " + shieldWarningThreshold + "%");

            if (level <= 0.0f)
                statusField.text = "GAME OVER"; 
        }

        // TODO: I should be using FixedUpdate instead to calculate the acceleration curve
        private IEnumerator UpdateSpeedMeter()
        {
            int currentSpeed = 0;
            while (true)
            {
                while (currentSpeed != newSpeed)
                {
                    yield return new WaitForSeconds(0.001f);
                    if (currentSpeed > newSpeed) currentSpeed--;
                    if (currentSpeed < newSpeed) currentSpeed++;
                    speedField.text = currentSpeed.ToString();
                }

                yield return null;
            }
        }

        public override void Notify(Subject subject)
        {
            BikeController controller = subject.GetComponent<BikeController>();
            UpdateShieldMeter(controller.bikeShield.strength);
            newSpeed = controller.currentSpeed;
        }

        public void RestartRace()
        {
            RaceEventBus.Publish(RaceEventType.RESTART);
        }
    }
}