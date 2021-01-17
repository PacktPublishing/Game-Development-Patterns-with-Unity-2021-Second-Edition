using UnityEngine;

namespace Chapter.EventBus
{
    public class ClientEventBus : MonoBehaviour
    {
        private void Start()
        {
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeController>();
            gameObject.AddComponent<HUDController>();
        }

        void Update()
        {
            if (Input.GetKeyDown("s"))
                RaceEventBus.Publish(RaceEventType.COUNTDOWN);

            if (Input.GetKeyDown(KeyCode.Escape))
                RaceEventBus.Publish(RaceEventType.PAUSE);
        }
    }
}