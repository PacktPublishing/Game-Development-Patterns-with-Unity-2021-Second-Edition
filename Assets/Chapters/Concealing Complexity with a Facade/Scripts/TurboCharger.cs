using UnityEngine;

namespace Chapter.Facade
{
    public class TurboCharger : MonoBehaviour
    {
        public float boostAmount;
        public float boostDuration;

        private bool isTurboOn;

        private void OnEnable()
        {
            EngineFacade.OnTogglingTurbo += ToggleTurbo;
            EngineFacade.OnTurnOff += StopTurbo;
        }

        private void OnDisable()
        {
            EngineFacade.OnTogglingTurbo -= ToggleTurbo;
            EngineFacade.OnTurnOff -= StopTurbo;
        }

        private void StopTurbo()
        {
            isTurboOn = false;
            Debug.Log("Turbo charge stopped");
        }

        private void ToggleTurbo()
        {
            isTurboOn = !isTurboOn;
            Debug.Log("The turbo charge is turned on? " + isTurboOn);
        }
    }
}