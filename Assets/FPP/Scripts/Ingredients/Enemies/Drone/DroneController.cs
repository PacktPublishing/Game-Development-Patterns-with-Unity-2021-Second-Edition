using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Interfaces;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using FPP.Scripts.Ingredients.Enemies.Drone.Components;
using FPP.Scripts.Ingredients.Enemies.Drone.Strategies;

namespace FPP.Scripts.Ingredients.Enemies.Drone
{
    public class DroneController : MonoBehaviour, IDamageable, IDestructible
    {
        [Header("Sensor")]
        public float sensorDistance;

        [Header("Weapon")] 
        public float beamAngle;
        public float beamDistance;
        public float weaponStrength;
        
        public Animator Animator { get; set; }
        
        private GameObject _target;
        private DroneSensor _droneSensor;
        private DroneWeapon _droneWeapon;
        private readonly List<IManeuverBehaviour> _strategyComponents = new();

        void Awake()
        {
            Animator = gameObject.GetComponent<Animator>();
        }

        void Start()
        {
            Activate();
        }

        private void ActivateSensor() // The drone sensor is deprecated at the moment
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
                _droneWeapon.ActivateWeapon(weaponStrength);
            }
        }
        
        private void ApplyAttackStrategy() // TODO: The appplication of strategies should not be random as it will cause issues with the replay system
        {
            _strategyComponents.Add(gameObject.AddComponent<WeavingManeuver>());
            _strategyComponents.Add(gameObject.AddComponent<BoppingManeuver>());
            _strategyComponents.Add(gameObject.AddComponent<FallbackManeuver>());

            int index = Random.Range(0, _strategyComponents.Count);
            
            _strategyComponents[index].Maneuver(this);
        }

        public void Activate() // TODO: Encapsulate this in an animation state class
        {
            ActivateWeapon();            
            ApplyAttackStrategy();
            
            Animator.SetTrigger("Activate");
        }

        public void TakeDamage(float amount, DamageType type)
        {
            throw new System.NotImplementedException();
        }

        public void Destruct()
        {
            throw new System.NotImplementedException();
        }
    }
}