using UnityEngine;
using System.Collections;

namespace FPP.Scripts.Ingredients.Bike.Engine
{
    public class FuelPump : MonoBehaviour
    {
        public IEnumerator burnFuel;
        public BikeEngine BikeEngine { get; set; }

        void Start()
        {
            burnFuel = BurnFuel();
        }

        IEnumerator BurnFuel()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                BikeEngine.fuelAmount -= BikeEngine.burnRate;

                if (BikeEngine.fuelAmount <= 0.0f)
                {
                    BikeEngine.TurnOff();
                    yield return 0;
                }
            }
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(
                new Rect(10, 40, 500, 20),
                "Fuel: " + BikeEngine.fuelAmount);
        }
    }
}