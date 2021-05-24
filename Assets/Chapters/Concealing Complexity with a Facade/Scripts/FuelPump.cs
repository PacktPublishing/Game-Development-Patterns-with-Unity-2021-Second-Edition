using UnityEngine;
using System.Collections;

namespace Chapter.Facade
{
    public class FuelPump : MonoBehaviour
    {
        public Engine engine;
        public IEnumerator burnFuel;

        void Start()
        {
            burnFuel = BurnFuel();
        }
        
        IEnumerator BurnFuel()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                engine.fuelAmount -= engine.burnRate;
                
                Debug.Log("Fuel: " + engine.fuelAmount);
                
                if (engine.fuelAmount <= 0.0f)
                {
                    engine.TurnOff();
                    yield return 0;
                }
            }
        }
    } 
}

