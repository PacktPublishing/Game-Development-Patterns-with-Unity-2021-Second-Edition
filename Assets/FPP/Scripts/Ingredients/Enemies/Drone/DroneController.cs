using UnityEngine;
using FPP.Scripts.Enums;
using System.Collections;
using FPP.Scripts.Controllers;
using System.Collections.Generic;
using FPP.Scripts.Ingredients.Enemies.Drone.Strategies;

namespace FPP.Scripts.Ingredients.Enemies.Drone
{
    public class DroneController : MonoBehaviour
    {
        private readonly List<IManeuverBehaviour> 
            _strategyComponents = new();

        private bool _isActived;
        private LineRenderer _line;
        private GameObject _target;
        private IEnumerator _activate;

        [Header("Sonar")]
        private RaycastHit _sonarHit;
        private Vector3 _sonarDirection;
        [SerializeField] private float _sonarDistance = 20.0f;

        [Header("Laser")]
        private RaycastHit _laserHit;
        private Vector3 _laserDirection;
        [SerializeField] private GameObject model;
        [SerializeField] private float _laserAngle = -45.0f;
        [SerializeField] private float _laserDistance = 15.0f;
        
        void Start()
        {
            _sonarDirection = transform.TransformDirection(Vector3.back) * _sonarDistance;
            
            Activate();
        }

        public void ApplyStrategy()
        {
            _strategyComponents.Add(gameObject.AddComponent<WeavingManeuver>());
            _strategyComponents.Add(gameObject.AddComponent<BoppingManeuver>());

            int index = Random.Range(0, _strategyComponents.Count);
            
            _strategyComponents[index].Maneuver(this);
        }

        private void Activate()
        {
            _isActived = true;
            
            DrawLaser();
            ApplyStrategy();
        }

        private void DrawLaser()
        {
            _line = model.AddComponent<LineRenderer>();
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
            if (!_isActived)
            {
                Vector3 _sonarOrigin = transform.position;
                _sonarOrigin.y = 0.5f;
                Debug.DrawRay(_sonarOrigin, _sonarDirection, Color.red);
                if (Physics.Raycast(_sonarOrigin, _sonarDirection, out _sonarHit, _sonarDistance))
                {
                    if (_sonarHit.collider.GetComponent<BikeController>())
                    {
                        Activate();
                    }
                }
            }
            
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