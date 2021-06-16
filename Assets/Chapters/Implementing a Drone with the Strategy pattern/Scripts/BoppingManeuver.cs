using UnityEngine;
using System.Collections;

namespace Chapter.Strategy
{
    public class BoppingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone)
        {
            StartCoroutine(Bopple(drone));
        }

        IEnumerator Bopple(Drone drone)
        {
            float time;
            bool isReverse = false;
            float speed = drone.Speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.y = drone.MaxHeight;

            while (true)
            {
                time = 0;
                Vector3 start = drone.transform.position;
                Vector3 end = (isReverse) ? startPosition : endPosition;

                while (time < speed)
                {
                    drone.transform.position = 
                        Vector3.Lerp(start, end, time / speed);
                    time += Time.deltaTime;
                    yield return null;
                }

                yield return new WaitForSeconds(1);
                isReverse = !isReverse;
            }
        }
    }
}
