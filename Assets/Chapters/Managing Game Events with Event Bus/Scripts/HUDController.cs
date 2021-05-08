using UnityEngine;

namespace Chapter.EventBus
{
    public class HUDController : MonoBehaviour
    {
        private string _raceStatus = "N/A";

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.PAUSE, DisplayPauseMenu);
            RaceEventBus.Subscribe(RaceEventType.START, DisplayStartMenu);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.PAUSE, DisplayPauseMenu);
            RaceEventBus.Unsubscribe(RaceEventType.START, DisplayStartMenu);
        }

        private void DisplayPauseMenu()
        {
            _raceStatus = "GAME PAUSED";
        }

        private void DisplayStartMenu()
        {
            _raceStatus = "GAME STARTED";
        }

        void OnGUI()
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(125, 30, 500, 20), _raceStatus);
        }
    }
}
