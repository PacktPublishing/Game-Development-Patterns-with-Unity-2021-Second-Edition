using TMPro;
using UnityEngine;
using FPP.Scripts.Controllers;

namespace FPP.Scripts.Ingredients.Pickups
{
    public class Pickup : MonoBehaviour
    {
        public PowerUpItem powerup;
        private TextMeshPro _title;

        private void Start()
        {
            _title = GetComponentInChildren<TextMeshPro>();
            _title.text = powerup.title;

            var render = GetComponent<Renderer>();
            render.material.SetColor("_Color", powerup.pickupColor);
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