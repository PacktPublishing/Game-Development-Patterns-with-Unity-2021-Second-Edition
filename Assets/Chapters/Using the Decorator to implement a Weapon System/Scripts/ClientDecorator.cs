using UnityEngine;

namespace Chapter.Decorator
{
    public class ClientDecorator : MonoBehaviour
    {
        private BikeWeapon _bikeWeapon;

        void Start()
        {
            _bikeWeapon = (BikeWeapon) FindObjectOfType(typeof(BikeWeapon));
        }

        void OnGUI()
        {
            if (GUILayout.Button("Fire Weapon"))
                _bikeWeapon.Fire();
            
            if (GUILayout.Button("Decorate Weapon"))
                _bikeWeapon.Decorate();
            
            if (GUILayout.Button("Reset Weapon"))
                _bikeWeapon.Reset();
        }
    }
}