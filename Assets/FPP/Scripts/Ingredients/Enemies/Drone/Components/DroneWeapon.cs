using System.Collections.Generic;
using FPP.Scripts.Controllers;
using FPP.Scripts.Enums;
using UnityEngine;

namespace FPP.Scripts.Ingredients.Enemies.Drone.Components
{
    public class DroneWeapon : MonoBehaviour
    {
        public bool isBeamOn;
        public DroneController DroneController { get; set; }

        private GameObject _target;
        private LineRenderer _line;
        private RaycastHit _laserHit;
        private Vector3 _laserDirection;

        public void ActivateWeapon()
        {
            _line = gameObject.AddComponent<LineRenderer>();
            _line.startWidth = 0.1f;
            _line.endWidth = 0.1f;
            _line.useWorldSpace = true;
            _line.material = new Material(Shader.Find("Sprites/Default"));
            _line.startColor = Color.red;

            _laserDirection = transform.TransformDirection(Vector3.back) * DroneController.laserDistance;
            _laserDirection = Quaternion.Euler(DroneController.laserAngle, 0.0f, 0f) * _laserDirection;

            _target = new GameObject("Target", typeof(BoxCollider));
            _target.transform.SetParent(transform);

            Vector3 pos = Quaternion.AngleAxis(DroneController.laserAngle, Vector3.right) * Vector3.back *
                          DroneController.laserDistance;
            _target.transform.localPosition = pos;

            isBeamOn = true;
        }

        void Update()
        {
            if (isBeamOn)
            {
                List<Vector3> pos = new List<Vector3>();
                pos.Add(transform.position);
                pos.Add(_target.transform.position);
                _line.SetPositions(pos.ToArray());

                Debug.DrawRay(transform.position, _laserDirection, Color.blue);
                if (Physics.Raycast(transform.position, _laserDirection, out _laserHit, DroneController.laserDistance))
                {
                    if (_laserHit.collider.GetComponent<BikeController>())
                    {
                        Debug.DrawRay(transform.position, _laserDirection, Color.green);
                        _laserHit.collider.GetComponent<BikeController>().Damage(DamageType.Laser);
                    }
                }
            }
        }
    }
}