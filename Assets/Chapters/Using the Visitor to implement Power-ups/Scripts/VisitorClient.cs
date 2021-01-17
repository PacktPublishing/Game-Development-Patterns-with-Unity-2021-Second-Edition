using UnityEngine;

namespace Pattern.Visitor
{
    public class VisitorClient : MonoBehaviour
    {
        public PowerUpItem enginePowerUp;
        public PowerUpItem shieldPowerUp;
        public PowerUpItem kamikazePowerUp;

        void Start()
        {
            BikeShield shield = gameObject.AddComponent<BikeShield>();
        
            shield.Accept(shieldPowerUp);
            Debug.Log(shield.strength.ToString());
        
            shield.Accept(enginePowerUp);
            Debug.Log(shield.strength.ToString());
        }
    }
}