using UnityEngine;
using System.Collections;

namespace Chapter.EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField]
        private float duration = 5.0f;

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartCount);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartCount);
        }

        public void StartCount()
        {
            StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            while (duration > 0)
            {
                yield return new WaitForSeconds(1f);
                duration--;
            }

            RaceEventBus.Publish(RaceEventType.START);
        }
        
        void OnGUI()
        {
            GUI.color = Color.blue;
            GUI.Label(new Rect(125, 0, 100, 20), "COUNTDOWN: " + duration);
        }
    }
}