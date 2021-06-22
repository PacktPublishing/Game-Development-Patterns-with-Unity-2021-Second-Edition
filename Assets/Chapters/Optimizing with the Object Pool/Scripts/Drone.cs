using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

namespace Chapter.ObjectPool 
{
    public class Drone : MonoBehaviour 
    {
        public IObjectPool<Drone> Pool { get; set; }

        public float _currentHealth;

        [SerializeField] 
        private float maxHealth = 100.0f;
        [SerializeField] 
        private float timeToSelfDestruct = 3.0f;

        void Start() 
        {
            _currentHealth = maxHealth;
        }
        
        void OnEnable() 
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        private void OnDisable() 
        {
            ResetDrone();
        }

        IEnumerator SelfDestruct() {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }
        
        private void ReturnToPool() {
            Pool.Release(this);
        }
        
        private void ResetDrone() {
            _currentHealth = maxHealth;
        }

        public void AttackPlayer() {
            Debug.Log("Attack player!");
        }

        public void TakeDamage(float amount) {
            _currentHealth -= amount;
            
            if (_currentHealth <= 0.0f)
                ReturnToPool();
        }
    }
}