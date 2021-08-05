using UnityEngine;

namespace FPP.Scripts.Ingredients.Enemies.Drones
{
    public class BoppingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        private Animator _animator;
        
        public void Maneuver(Drone drone)
        {
            _animator = gameObject.GetComponent<Animator>();
            
            if (_animator)
                _animator.SetTrigger("Bopple");
            else
                Debug.LogError("Animator not found!");
        }
    }
}