using UnityEngine;

namespace Chapter.EventBus
{
    public class ClientEventBus : MonoBehaviour
    {
        private void Start()
        {
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeController>();
        }

        void OnGUI()
        {
            if (GUILayout.Button("Start Countdown"))
                RaceEventBus.Publish(RaceEventType.COUNTDOWN);

            if (GUILayout.Button("Pause Game"))
                RaceEventBus.Publish(RaceEventType.PAUSE);
        }
    }
}