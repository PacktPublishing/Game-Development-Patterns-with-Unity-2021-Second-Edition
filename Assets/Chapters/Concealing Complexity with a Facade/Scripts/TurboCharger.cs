using UnityEngine;
using System.Collections;

namespace Chapter.Facade
{
    public class TurboCharger : MonoBehaviour
    {
        public Engine engine;
        
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
            _coolingSystem.ToggleCoolingPausing();
            Debug.Log("Turbo started");
            
            yield return new WaitForSeconds(engine.turboDuration);
            
            _isTurboOn = false;
            _coolingSystem.ToggleCoolingPausing();
            Debug.Log("Turbo stopped");
        }
    }
}