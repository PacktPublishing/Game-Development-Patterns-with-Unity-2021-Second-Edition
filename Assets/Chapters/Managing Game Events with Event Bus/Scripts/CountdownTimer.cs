using UnityEngine;
using System.Collections;

namespace Chapter.EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField]
        private float _duration = 5.0f;

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartCount);
        }

        void OnDisable()
        {
           if(RaceEventBus.Instance) RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartCount);
        }

        public void StartCount()
        {
            StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            while (_duration > 0)
            {
                Debug.Log(_duration.ToString());
                yield return new WaitForSeconds(1f);
                _duration--;
            }

            RaceEventBus.Publish(RaceEventType.START);
            Destroy(this);
        }
    }
}