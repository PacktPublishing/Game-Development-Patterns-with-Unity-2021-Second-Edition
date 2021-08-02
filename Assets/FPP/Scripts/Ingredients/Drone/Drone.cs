using UnityEngine;
using System.Collections;
using FPP.Scripts.Controllers;
using System.Collections.Generic;

public class Drone : MonoBehaviour
{
    public float Speed = 1.0f;
    public float MaxHeight = 5.0f;
    public float MinHeight = 1.5f;
    public float WeavingDistance = 1.5f;
    public IManeuverBehaviour strategy;
    
    private bool _isActived;
    private LineRenderer _line;
    private GameObject _target;
    private IEnumerator _activate;
    
    // Sonar
    private RaycastHit _sonarHit;
    private Vector3 _sonarDirection;
    [SerializeField] private float _sonarDistance = 20.0f;
    
    // Laser
    private RaycastHit _laserHit;
    private Vector3 _laserDirection;
    [SerializeField] private float _laserAngle = -45.0f;
    [SerializeField] private float _laserDistance = 15.0f;
    
    void Start()
    {
        _sonarDirection = transform.TransformDirection(Vector3.back) * _sonarDistance;
        Activate();
    }
    
    public void ApplyStrategy()
    {
        strategy.Maneuver(this);
    }

    private void Activate()
    {
        strategy = gameObject.AddComponent<BoppingManeuver>();
        ApplyStrategy();
        
        _isActived = true;
        DrawLaser();
    }

    private void DrawLaser()
    {
        _line = gameObject.AddComponent<LineRenderer>();
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.useWorldSpace = true;
        _line.material = new Material(Shader.Find("Sprites/Default"));
        _line.SetColors(Color.red, Color.red);
        
        _laserDirection = transform.TransformDirection(Vector3.back) * _laserDistance;
        _laserDirection = Quaternion.Euler(_laserAngle, 0.0f, 0f) * _laserDirection;
        _target = new GameObject("Target",  typeof(BoxCollider));
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
        
        // Laser
        if (_isActived)
        {
            List<Vector3> pos = new List<Vector3>();
            pos.Add(transform.position);
            pos.Add(_target.transform.position);
            _line.SetPositions(pos.ToArray());

            Debug.DrawRay(transform.position, _laserDirection, Color.blue);
            if (Physics.Raycast(transform.position, _laserDirection, out _laserHit, _laserDistance))
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