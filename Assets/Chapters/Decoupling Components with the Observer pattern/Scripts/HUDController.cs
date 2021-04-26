using UnityEngine;

namespace Chapter.Observer
{
    public class HUDController : Observer
    {
        private bool _isTurboOn;
        private float _currentHealth;
        
        void OnGUI()
        {
            GUILayout.BeginHorizontal ("box");
            GUILayout.Label ("Health: " + _currentHealth);        
            GUILayout.EndHorizontal ();

            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated!");
                GUILayout.EndHorizontal();
            }
        }

        public override void Notify(Subject subject)
        {
            BikeController controller = subject.GetComponent<BikeController>();
            if (controller)
            {
                _isTurboOn = controller.IsTurboOn;
                _currentHealth = controller.CurrentHealth;
            }
        }
    }
}
