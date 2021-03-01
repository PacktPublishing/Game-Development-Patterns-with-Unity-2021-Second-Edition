using UnityEngine;

namespace Pattern.Visitor
{
    public class VisitorClient : MonoBehaviour
    {
        public PowerUpItem enginePowerUp;
        public PowerUpItem shieldPowerUp;
        public PowerUpItem weaponPowerUp;
        
        private BikeController _bikeController;

        void Start()
        {
            _bikeController = gameObject.AddComponent<BikeController>();
        }

        void OnGUI()
        {
            GUILayout.Label("Output in console");
            
            if (GUILayout.Button("PowerUp Shield"))
                _bikeController.Accept(shieldPowerUp);

            if (GUILayout.Button("PowerUp Engine"))
                _bikeController.Accept(enginePowerUp);
            
            if (GUILayout.Button("PowerUp Weapon"))
                _bikeController.Accept(weaponPowerUp);
        }
    }
}