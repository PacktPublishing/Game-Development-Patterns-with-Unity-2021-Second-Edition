using UnityEngine;
using System.Collections;

namespace FPP.Scripts.Ingredients.Bike.Engine
{
    public class TurboCharger : MonoBehaviour
    {
        public BikeEngine BikeEngine { get; set; }
        public bool IsTurboOn { get; private set; }
        
        private CoolingSystem _coolingSystem;

        public void ToggleTurbo(CoolingSystem coolingSystem)
        {
            _coolingSystem = coolingSystem;
           
            if (BikeEngine.IsEngineOn) 
                StartCoroutine(TurboCharge());
        }

        IEnumerator TurboCharge()
        {
            IsTurboOn = true;
            
            _coolingSystem.PauseCooling();
            
            BikeEngine.CurrentSpeed = 
                BikeEngine.CurrentSpeed + (BikeEngine.CurrentSpeed * BikeEngine.TurboBoostAmount / 100);

            yield return new WaitForSeconds(BikeEngine.TurboDuration);

            IsTurboOn = false;
            
            _coolingSystem.PauseCooling();
            
            if (BikeEngine.IsEngineOn) 
                BikeEngine.CurrentSpeed = BikeEngine.DefaultSpeed;
        }
    }
}