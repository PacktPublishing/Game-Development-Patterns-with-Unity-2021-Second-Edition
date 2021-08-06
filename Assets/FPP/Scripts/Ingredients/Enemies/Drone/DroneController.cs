using UnityEngine;
using FPP.Scripts.Enums;
using System.Collections;
using FPP.Scripts.Controllers;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using FPP.Scripts.Ingredients.Enemies.Drone.Components;
using FPP.Scripts.Ingredients.Enemies.Drone.Strategies;

namespace FPP.Scripts.Ingredients.Enemies.Drone
{
    public class DroneController : MonoBehaviour
    {
        public Animator Animator { get; set; }

        private bool _isActived;
        private LineRenderer _line;
        private GameObject _target;
        private readonly List<IManeuverBehaviour> 
            _strategyComponents = new();
        
        [Header("Sensor")]
        public float sensorDistance = 20.0f;
        private DroneSensor _droneSensor;

        // TODO: Move this segment into the DroneWeapon class
        [Header("Weapon")]
        private RaycastHit _laserHit;
        private Vector3 _laserDirection;
        [SerializeField] private GameObject model;
        [SerializeField] private float _laserAngle = -45.0f;
        [SerializeField] private float _laserDistance = 15.0f;

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
        
        private void ApplyAttackStrategy()
        {
            _strategyComponents.Add(gameObject.AddComponent<WeavingManeuver>());
            _strategyComponents.Add(gameObject.AddComponent<BoppingManeuver>());

            int index = Random.Range(0, _strategyComponents.Count);
            
            _strategyComponents[index].Maneuver(this);
        }

        public void Activate()
        {
            Animator.SetTrigger("Activate");
                
            // TODO: Encapsulate this in an animation state class
            DrawLaser();
            ApplyAttackStrategy();
            
            _isActived = true;
        }

        // TODO: Move this segment into the DroneWeapon class
        private void DrawLaser()
        {
            _line = gameObject.AddComponent<LineRenderer>();
            _line.startWidth = 0.1f;
            _line.endWidth = 0.1f;
            _line.useWorldSpace = true;
            _line.material = new Material(Shader.Find("Sprites/Default"));
            _line.startColor = Color.red;

            _laserDirection = transform.TransformDirection(Vector3.back) * _laserDistance;
            _laserDirection = Quaternion.Euler(_laserAngle, 0.0f, 0f) * _laserDirection;
            _target = new GameObject("Target", typeof(BoxCollider));
            _target.transform.SetParent(transform);

            Vector3 pos = Quaternion.AngleAxis(_laserAngle, Vector3.right) * Vector3.back * _laserDistance;
            _target.transform.localPosition = pos;
        }

        void Update()
        {
            // TODO: Move this segment into the DroneWeapon classs
            if (_isActived)
            {
                List<Vector3> pos = new List<Vector3>();
                pos.Add(model.transform.position);
                pos.Add(_target.transform.position);
                _line.SetPositions(pos.ToArray());

                Debug.DrawRay(transform.position, _laserDirection, Color.blue);
                if (Physics.Raycast(model.transform.position, _laserDirection, out _laserHit, _laserDistance))
                {
                    if (_laserHit.collider.GetComponent<BikeController>())
                    {
                        Debug.DrawRay(model.transform.position, _laserDirection, Color.green);
                        _laserHit.collider.GetComponent<BikeController>().Damage(DamageType.Laser);
                    }
                }
            }
        }
    }
}