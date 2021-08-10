using UnityEngine;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Ingredients.Enemies.Drone.Components
{
    public class DroneSensor : MonoBehaviour
    {
        public bool isSensorOn;
        public DroneController DroneController { get; set; }
        
        private RaycastHit _sensorHit;
        private Vector3 _sensorOrigin;
        private Vector3 _sensorDirection;
        
        void Start()
        {
            if (DroneController) 
                _sensorDirection = transform.TransformDirection(Vector3.forward) * DroneController.sensorDistance;
        }

        void Update()
        {
            if (isSensorOn)
            {
                _sensorOrigin = transform.position;

                Debug.DrawRay(_sensorOrigin, _sensorDirection, Color.green);

                if (Physics.Raycast(_sensorOrigin, _sensorDirection, out _sensorHit, DroneController.sensorDistance))
                {
                    if (_sensorHit.collider.GetComponent<BikeController>())
                    {
                        DroneController.Activate();
                        isSensorOn = false;
                    }
                }
            }
        }
    }
}
