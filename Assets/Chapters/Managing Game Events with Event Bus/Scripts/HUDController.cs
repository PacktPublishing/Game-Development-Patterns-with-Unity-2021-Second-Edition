using UnityEngine;

namespace Chapter.EventBus
{
    public class HUDController : MonoBehaviour
    {
        private bool isButtonEnabled;

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, DisplayRestartButton);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, DisplayRestartButton);
        }
        
        private void DisplayRestartButton()
        {
            isButtonEnabled = true;
        }

        void OnGUI()
        {
            if (isButtonEnabled)
            {
                if (GUILayout.Button("Restart Race"))
                {
                    isButtonEnabled = false;
                    RaceEventBus.Publish(RaceEventType.RESTART);
                }
            }
        }
    }
}
