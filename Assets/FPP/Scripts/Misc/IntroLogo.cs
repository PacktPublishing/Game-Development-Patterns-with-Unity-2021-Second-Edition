using UnityEngine;
using System.Collections;

public class IntroLogo : MonoBehaviour
{
    [SerializeField]
    private float m_Duration = 7.0f;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (m_Duration > 0)
        {
            yield return new WaitForSeconds(1f);
            m_Duration--;
            Debug.Log(m_Duration);
        }
    }
}