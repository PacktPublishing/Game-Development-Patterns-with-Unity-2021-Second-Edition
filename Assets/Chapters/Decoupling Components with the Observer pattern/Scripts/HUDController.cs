using UnityEngine;

namespace Chapter.Observer
{
    public class HUDController : Observer
    {
        private bool _isTurboOn;
        private float _currentHealth;
        
        void OnGUI()
        {
            GUILayout.BeginArea (new Rect (50,50,100,100));
           
            GUILayout.BeginHorizontal ("box");
            GUILayout.Label ("Health: " + _currentHealth);
            GUILayout.EndHorizontal ();

            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated!");
                GUILayout.EndHorizontal();
            }
            
            if (_currentHealth <= 50.0f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("WARNING: Low Health");
                GUILayout.EndHorizontal();
            }
            
            GUILayout.EndArea ();
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
