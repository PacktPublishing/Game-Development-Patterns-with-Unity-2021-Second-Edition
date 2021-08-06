using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using FPP.Scripts.Ingredients.Enemies.Drone.Components;
using FPP.Scripts.Ingredients.Enemies.Drone.Strategies;

namespace FPP.Scripts.Ingredients.Enemies.Drone
{
    public class DroneController : MonoBehaviour
    {
        [Header("Sensor")]
        public float sensorDistance = 20.0f;

        [Header("Weapon")]
        public float laserAngle = -45.0f;
        public float laserDistance = 15.0f;

        public Animator Animator { get; set; }
        
        private GameObject _target;
        private DroneSensor _droneSensor;
        private DroneWeapon _droneWeapon;
        private readonly List<IManeuverBehaviour> _strategyComponents = new();

        void Awake()
        {
            Animator = gameObject.GetComponent<Animator>();
            ActivateSensor();
        }

        private void ActivateSensor()
        {
            _droneSensor = GetComponentInChildren<DroneSensor>();

            if (_droneSensor)
            {
                _droneSensor.DroneController = this;
                _droneSensor.isSensorOn = true;
            }
            else
            {
                Debug.LogError("Drone sensor component not found!");
            }
        }

        private void ActivateWeapon()
        {
            _droneWeapon = GetComponentInChildren<DroneWeapon>();

            if (_droneWeapon)
            {
                _droneWeapon.DroneController = this;
                _droneWeapon.ActivateWeapon();
            }
        }
        
        private void ApplyAttackStrategy()
        {
            _strategyComponents.Add(gameObject.AddComponent<WeavingManeuver>());
            _strategyComponents.Add(gameObject.AddComponent<BoppingManeuver>());

            int index = Random.Range(0, _strategyComponents.Count);
            
            _strategyComponents[index].Maneuver(this);
        }

        public void Activate() // TODO: Encapsulate this in an animation state class
        {
            ActivateWeapon();            
            ApplyAttackStrategy();
            
            Animator.SetTrigger("Activate");
        }
    }
}