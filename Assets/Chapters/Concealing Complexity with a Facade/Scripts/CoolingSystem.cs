using UnityEngine;
using System.Collections;

namespace Chapter.Facade {
    public class CoolingSystem : MonoBehaviour {
        
        public BikeEngine engine;
        public IEnumerator coolEngine;
        private bool _isPaused;

        void Start() {
            coolEngine = CoolEngine();
        }

        public void PauseCooling() {
            _isPaused = !_isPaused;
        }

        public void ResetTemperature() {
            engine.currentTemp = 0.0f;
        }

        IEnumerator CoolEngine() {
            while (true) {
                yield return new WaitForSeconds(1);

                if (!_isPaused) {
                    if (engine.currentTemp > engine.minTemp)
                        engine.currentTemp -= engine.tempRate;
                    if (engine.currentTemp < engine.minTemp)
                        engine.currentTemp += engine.tempRate;
                } else {
                    engine.currentTemp += engine.tempRate;
                }

                if (engine.currentTemp > engine.maxTemp)
                    engine.TurnOff();
            }
        }

        void OnGUI() {
            GUI.color = Color.green;
            GUI.Label(
                new Rect(100, 20, 500, 20), 
                "Temp: " +  engine.currentTemp);
        }
    }
}