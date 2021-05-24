using UnityEngine;

namespace Chapter.Facade
{
    public class ClientFacade : MonoBehaviour
    {
        private Engine _engine;
    
        void Start()
        {
            _engine = gameObject.AddComponent<Engine>();
        }
        
        void OnGUI()
        {
            GUILayout.Label("Output in console");

            if (GUILayout.Button("Start Engine"))
                _engine.TurnOn();
            
            if (GUILayout.Button("Stop Engine"))
                _engine.TurnOff();
            
            if (GUILayout.Button("Toggle Turbo"))
                _engine.ToggleTurbo();
        }
    }
}