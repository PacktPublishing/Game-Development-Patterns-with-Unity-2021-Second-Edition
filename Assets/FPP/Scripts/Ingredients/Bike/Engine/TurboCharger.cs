using UnityEngine;
using System.Collections;

namespace FPP.Scripts.Ingredients.Bike.Engine
{
    public class TurboCharger : MonoBehaviour
    {
        public BikeEngine BikeEngine { get; set; }

        private bool _isTurboOn;
        private CoolingSystem _coolingSystem;

        public void ToggleTurbo(CoolingSystem coolingSystem)
        {
            _coolingSystem = coolingSystem;

            if (!_isTurboOn)
                StartCoroutine(TurboCharge());
        }

        IEnumerator TurboCharge()
        {
            _isTurboOn = true;
            _coolingSystem.PauseCooling();

            yield return new WaitForSeconds(BikeEngine.turboDuration);

            _isTurboOn = false;
            _coolingSystem.PauseCooling();
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(
                new Rect(10, 60, 500, 20),
                "Turbo Activated: " + _isTurboOn);
        }
    }
}