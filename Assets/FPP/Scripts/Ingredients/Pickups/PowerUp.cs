using TMPro;
using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Ingredients.Pickups
{
    public class PowerUp : MonoBehaviour
    {
        public PowerUpItem powerup;
        private TextMeshPro _title;

        private void Start()
        {
            if (powerup)
            {
                _title = GetComponentInChildren<TextMeshPro>();
                _title.text = powerup.title;

                // TODO: Write a custom shader for the powerups
                //var render = GetComponent<Renderer>();
                //render.material.SetColor("_Color", powerup.pickupColor);
            }
            else
            {
                Debug.LogError("Missing powerup item");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            BikeController controller = other.GetComponent<BikeController>();
            
            if (controller)
            {
                controller.Accept(powerup);
                Destroy(gameObject);
            }
        }
    }
}