using UnityEngine;

namespace Chapter.Decorator
{
    public class BikeWeapon : MonoBehaviour
    {
        public WeaponConfig weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment secondaryAttachment;

        private bool _isFiring;
        private IWeapon _weapon;
        private float _beamTimer;
        private Vector3 _startPosition;

        void Start()
        {
            _weapon = new Weapon(weaponConfig);
            DecorateWeapon();
        }

        void Update()
        {
            if (_isFiring)
            {
                _startPosition = transform.position;
                Debug.DrawRay(_startPosition, transform.TransformDirection(Vector3.left) * _weapon.Range, Color.red);
                
                if (_beamTimer > 0)
                    _beamTimer -= Time.deltaTime;
                else
                    _isFiring = false;
            }
        }

        void OnGUI()
        {
            GUILayout.BeginArea (new Rect (50,50,100,100));
            GUILayout.BeginHorizontal ("box");
            GUILayout.Label ("Range: " + _weapon.Range);
            GUILayout.EndHorizontal ();
            GUILayout.BeginHorizontal ("box");
            GUILayout.Label ("Strength: " + _weapon.Strength);
            GUILayout.EndHorizontal ();
            GUILayout.EndArea ();
        }

        public void Fire()
        {
            _beamTimer = _weapon.Duration;
            _isFiring = true;
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