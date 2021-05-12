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
            if (GUILayout.Button("Fire"))
                _bikeWeapon.Fire();
        }
    }
}