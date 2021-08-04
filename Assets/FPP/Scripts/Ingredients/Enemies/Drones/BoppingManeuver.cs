using UnityEngine;
using System.Collections;

namespace FPP.Scripts.Ingredients.Enemies.Drones
{
    public class BoppingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone)
        {
            StartCoroutine(Bopple(drone));
        }

        IEnumerator Bopple(Drone drone)
        {
            bool isReverse = false;
            float speed = drone.Speed;

            while (true)
            {
                float time = 0;
                float start = (isReverse) ? drone.MaxHeight : drone.MinHeight;
                float end = (isReverse) ? drone.MinHeight : drone.MaxHeight;

                while (time < speed)
                {
                    drone.transform.position = new Vector3(transform.position.x, Mathf.Lerp(start, end, time / speed),
                        drone.transform.position.z);

                    time += Time.deltaTime;
                    yield return null;
                }

                yield return new WaitForSeconds(1);
                isReverse = !isReverse;
            }
        }
    }
}