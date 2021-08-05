using UnityEngine;

namespace FPP.Scripts.Ingredients.Enemies.Drones
{
    public class WeavingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        private Animator _animator;

        public void Maneuver(Drone drone)
        {
            _animator = gameObject.GetComponent<Animator>();
            
            if (_animator)
                _animator.SetTrigger("Weave");
            else
                Debug.LogError("Animator not found!");
        }
    }
}