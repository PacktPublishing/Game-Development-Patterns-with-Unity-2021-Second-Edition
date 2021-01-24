using UnityEngine;
using System.Collections;

public class BoppingManeuver : MonoBehaviour, IManeuverBehaviour
{
    private Drone _drone;
    private Vector3 _upPosition;
    private Vector3 _startPosition;

    public void Maneuver(Drone drone)
    {
        _drone = drone;

        _upPosition = _drone.transform.position;
        _upPosition.y = drone.MaxHeight;
        _startPosition = _drone.transform.position;

        StartCoroutine(Bopple(drone.Speed));
    }

    IEnumerator Bopple(float cycleDuration)
    {
        bool isUp = false;
        while (true)
        {
            float time = 0;
            Vector3 startPosition = _drone.transform.position;
            Vector3 targetPosition = (isUp) ? _startPosition : _upPosition;

            while (time < cycleDuration)
            {
                _drone.transform.position = Vector3.Lerp(startPosition, targetPosition, time / cycleDuration);
                time += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(1);
            isUp = !isUp;
        }
    }
}
