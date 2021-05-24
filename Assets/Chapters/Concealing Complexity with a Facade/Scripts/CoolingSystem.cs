using UnityEngine;
using System.Collections;

namespace Chapter.Facade
{
    public class CoolingSystem : MonoBehaviour
    {
        public Engine engine;
        public IEnumerator coolEngine;
       
        private bool _isPaused;

        void Start()
        {
            coolEngine = CoolEngine();
        }

        public void ToggleCoolingPausing()
        {
            _isPaused = !_isPaused;
        }

        IEnumerator CoolEngine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                if (!_isPaused)
                {
                    if (engine.currentTemp > engine.minTemp)
                        engine.currentTemp -= engine.tempRate;

                    if (engine.currentTemp < engine.minTemp)
                        engine.currentTemp += engine.tempRate;
                }
                else
                {
                    engine.currentTemp += engine.tempRate;
                }
                
                if (engine.currentTemp > engine.maxTemp)
                    engine.TurnOff();

                Debug.Log("Temp: " + engine.currentTemp);
            }
        }
    }
}