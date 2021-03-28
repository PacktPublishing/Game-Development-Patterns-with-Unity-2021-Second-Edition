using UnityEngine;

namespace Chapter.Facade
{
    public class ClientFacade : MonoBehaviour
    {
        private EngineFacade _engineFacade;
    
        void Start()
        {
            _engineFacade = gameObject.AddComponent<EngineFacade>();
        }
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                _engineFacade.TurnOn();
            
            if (Input.GetKeyDown(KeyCode.D))
                _engineFacade.TurnOff();
            
            if (Input.GetKeyDown(KeyCode.T))
                _engineFacade.ToggleTurbo();
        }
    }
}

