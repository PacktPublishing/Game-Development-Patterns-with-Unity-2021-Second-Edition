using UnityEngine;

namespace Chapter.Facade
{
    public class CoolingSystem : MonoBehaviour
    {
        public bool isCoolingOn;
        public float maxTemperature;
        public float minTemperature;
        
        private void OnEnable()
        {
            EngineFacade.OnTurnOn += ToggleCooling;
            EngineFacade.OnTurnOff += ToggleCooling;
        }

        private void OnDisable()
        {
            EngineFacade.OnTurnOn -= ToggleCooling;
            EngineFacade.OnTurnOff -= ToggleCooling;
        }
        
        public void ToggleCooling()
        {
            isCoolingOn = !isCoolingOn;
            Debug.Log("The cooling system is turned on? " + isCoolingOn);
        }
    }
}

