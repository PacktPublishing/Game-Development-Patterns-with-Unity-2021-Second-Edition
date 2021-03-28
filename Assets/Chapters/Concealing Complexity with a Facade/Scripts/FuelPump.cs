using System;
using UnityEngine;

namespace Chapter.Facade
{
    public class FuelPump : MonoBehaviour
    {
        public float fuelAmount
        {
            get;
            private set;
        }

        public delegate void TankEmpty();
        public static event TankEmpty OnTankEmpty;

        private bool _isPumpOn;

        private void OnEnable()
        {
            EngineFacade.OnTurnOn += TogglePump;
            EngineFacade.OnTurnOff += TogglePump;
        }

        private void OnDisable()
        {
            EngineFacade.OnTurnOn -= TogglePump;
            EngineFacade.OnTurnOff -= TogglePump;
        }

        public void AddFuel(float Amount)
        {
            if (!_isPumpOn) fuelAmount = Amount;
        }

        public void TogglePump()
        {
            _isPumpOn = !_isPumpOn;
            Debug.Log("The fuel pump is turned on? " + _isPumpOn);
        }
    } 
}

