using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FPP.Scripts.Patterns;

namespace FPP.Scripts.UI
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private Text textField;
        [SerializeField] private float duration;
        [SerializeField] private string startMessage;

        public void StartTimer()
        {
            StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            while (duration > 0)
            {
                textField.text = duration.ToString();
                yield return new WaitForSeconds(1f);
                duration--;
            }

            textField.text = startMessage;

            yield return new WaitForSeconds(0.5f);
            RaceEventBus.Publish(RaceEventType.START);
            Destroy(gameObject);
        }
    }
}