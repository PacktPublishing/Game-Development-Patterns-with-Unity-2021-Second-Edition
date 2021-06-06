using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    private float _duration = 10.0f;

    IEnumerator Start()
    {
        Debug.Log("Timer Started!");
        yield return StartCoroutine(WaitAndPrint(1.0F));
        Debug.Log("Timer Ended!");
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        while (Time.time < _duration)
        {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Seconds: " + Mathf.Round(Time.time));
        }
    }
}