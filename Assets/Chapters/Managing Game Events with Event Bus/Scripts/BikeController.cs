using UnityEngine;

namespace Chapter.EventBus
{
    public class BikeController : MonoBehaviour
    {
        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, ReleaseBike);
            RaceEventBus.Subscribe(RaceEventType.PAUSE, PauseBike);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, ReleaseBike);
            RaceEventBus.Unsubscribe(RaceEventType.PAUSE, PauseBike);
        }

        public void ReleaseBike()
        {
            Debug.Log("The bike is released");
        }

        public void PauseBike()
        {
            Debug.Log("The bike is paused");
        }
    }
}