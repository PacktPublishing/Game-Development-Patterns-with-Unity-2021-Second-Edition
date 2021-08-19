using UnityEngine;
using FPP.Scripts.Weaponry;

namespace FPP.Scripts.Ingredients.Bike.Elements
{
    public class BikeWeapon : MonoBehaviour
    {
        public bool isDebugOn;
        public WeaponConfiguration weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment secondaryAttachment;

        private IWeapon _weapon;
        private float _beamTimer;
        private LineRenderer _beam;
        private Vector3 _startPosition;
        private Vector3 _currentPosition;

        void Start()
        {
            InitWeapon();
        }

        void Update()
        {
            _startPosition = transform.position;
            
            if (isDebugOn)
                Debug.DrawRay(_startPosition, transform.TransformDirection(Vector3.forward) * _weapon.range, Color.green);

            if (_beam.enabled)
            {
                _beam.SetPosition(0, _startPosition);
                _beam.SetPosition(1, _startPosition + transform.forward * _weapon.range);

                if (_beamTimer > 0)
                    _beamTimer -= Time.deltaTime;
                else
                    _beam.enabled = false;
            }
        }

        public void Fire()
        {
            _beamTimer = _weapon.fireTime;
            _beam.enabled = true;
        }

        private void InitWeapon()
        {
            _weapon = new Weapon(weaponConfig);
            DecorateWeapon();
            InitBeam();
        }

        private void InitBeam()
        {
            _beam = gameObject.AddComponent<LineRenderer>();
            _beam.startWidth = 0.05f;
            _beam.endWidth = 0.05f;
            _beam.useWorldSpace = true;
            _beam.material = new Material(Shader.Find("Sprites/Default"));
            _beam.startColor = _weapon.BeamColor;
            _beam.enabled = false;
        }

        private void DecorateWeapon()
        {
            if (mainAttachment && !secondaryAttachment)
                _weapon = new WeaponDecorator(_weapon, mainAttachment);

            if (mainAttachment && secondaryAttachment)
                _weapon = new WeaponDecorator(new WeaponDecorator(_weapon, mainAttachment), secondaryAttachment);
        }
    }
}