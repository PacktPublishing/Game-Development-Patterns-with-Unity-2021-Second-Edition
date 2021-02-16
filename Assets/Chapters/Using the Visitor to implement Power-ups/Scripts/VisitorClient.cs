using UnityEngine;

namespace Pattern.Visitor
{
    public class VisitorClient : MonoBehaviour
    {
        public PowerUpItem enginePowerUp;
        public PowerUpItem shieldPowerUp;
        public BikeController bikeController; 

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Applying the shield power-up");
                bikeController.Accept(shieldPowerUp);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Applying the engine power-up");
                bikeController.Accept(enginePowerUp);
            }
        }
    }
}