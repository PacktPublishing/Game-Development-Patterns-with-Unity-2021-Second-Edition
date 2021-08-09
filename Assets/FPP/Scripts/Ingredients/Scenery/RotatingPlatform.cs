using UnityEngine;

namespace FPP.Scripts.Ingredients.Scenery
{
    public class RotatingPlatform : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;

        void Update()
        {
            transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
        }
    }
}