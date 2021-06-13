using UnityEngine;

namespace Chapter.Facade
{
    public class ClientFacade : MonoBehaviour
    {
        private BikeEngine _bikeEngine;
    
        void Start()
        {
            _bikeEngine = 
                gameObject.AddComponent<BikeEngine>();
        }
        
        void OnGUI()
        {
            if (GUILayout.Button("Turn On"))
                _bikeEngine.TurnOn();
            
            if (GUILayout.Button("Turn Off"))
                _bikeEngine.TurnOff();
            
            if (GUILayout.Button("Toggle Turbo"))
                _bikeEngine.ToggleTurbo();
        }
    }
}