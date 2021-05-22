using UnityEngine;

namespace Chapter.Decorator
{
    public class BikeWeapon : MonoBehaviour
    {
        public WeaponConfig weaponConfig;
        public WeaponAttachment fstAttachment;
        public WeaponAttachment secAttachment;

        private bool _isFiring;
        private IWeapon _weapon;
        private float _beamTimer;
        private Vector3 _startPosition;
        private Vector3 _beamDirection;

        void Start()
        {
            _weapon = new Weapon(weaponConfig);
        }

        void Update()
        {
            if (_isFiring)
            {
                _startPosition = transform.position;
                _beamDirection = transform.TransformDirection(Vector3.left);
                Debug.DrawRay(_startPosition, _beamDirection * _weapon.Range, Color.red);
                
                if (_beamTimer > 0)
                    _beamTimer -= Time.deltaTime;
                else
                    _isFiring = false;
            }
        }

        void OnGUI()
        {
            GUILayout.BeginArea (new Rect (25,100,100,100));
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


        public void Reset()
        {
            _weapon = new Weapon(weaponConfig);
        }
        
        public void Decorate()
        {
            if (fstAttachment && !secAttachment)
                _weapon = new WeaponDecorator(_weapon, fstAttachment);

            if (fstAttachment && secAttachment)
                _weapon = 
                    new WeaponDecorator(new WeaponDecorator(_weapon, fstAttachment), secAttachment);
        }
    }
}