using UnityEngine;

namespace Chapter.EventBus
{
    public class HUDController : MonoBehaviour
    {
        private bool isRacePaused;
        private bool isRaceStarted;
        private float _currentTime;

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, DisplayRaceTimer);
            RaceEventBus.Subscribe(RaceEventType.PAUSE, DisplayPauseMenu);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, DisplayRaceTimer);
            RaceEventBus.Unsubscribe(RaceEventType.PAUSE, DisplayPauseMenu);
        }

        private void DisplayPauseMenu()
        {
            isRacePaused = !isRacePaused;
        }

        private void DisplayRaceTimer()
        {
            isRaceStarted = true;
        }

        void FixedUpdate()
        {
            if (isRaceStarted)
            {
                _currentTime += Time.deltaTime;
            }
        }

        void OnGUI()
        {
            GUI.color = Color.black;
            if (isRacePaused) GUI.Label(new Rect(10, 10, 500, 20), "The race is paused.");
            if (isRaceStarted && !isRacePaused) GUI.Label(new Rect(10, 10, 500, 20), _currentTime.ToString());
        }
    }
}

