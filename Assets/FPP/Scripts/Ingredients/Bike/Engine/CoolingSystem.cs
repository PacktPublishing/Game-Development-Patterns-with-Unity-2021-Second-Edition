using UnityEngine;
using System.Collections;

namespace FPP.Scripts.Ingredients.Bike.Engine
{
    public class CoolingSystem : MonoBehaviour
    {
        public IEnumerator coolEngine;
        public BikeEngine BikeEngine { get; set; }

        private bool _isPaused;

        void Start()
        {
            coolEngine = CoolEngine();
        }

        public void PauseCooling()
        {
            _isPaused = !_isPaused;
        }

        public void ResetTemperature()
        {
            BikeEngine.currentTemp = 0.0f;
        }

        IEnumerator CoolEngine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                if (!_isPaused)
                {
                    if (BikeEngine.currentTemp > BikeEngine.minTemp)
                        BikeEngine.currentTemp -= BikeEngine.tempRate;

                    if (BikeEngine.currentTemp < BikeEngine.minTemp)
                        BikeEngine.currentTemp += BikeEngine.tempRate;
                }
                else
                {
                    BikeEngine.currentTemp += BikeEngine.tempRate;
                }

                if (BikeEngine.currentTemp > BikeEngine.maxTemp)
                    BikeEngine.TurnOff();
            }
        }
    }
}