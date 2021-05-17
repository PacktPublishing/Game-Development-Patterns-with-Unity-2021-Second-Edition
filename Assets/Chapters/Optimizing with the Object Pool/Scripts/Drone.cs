using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> pool { get; set; }

        private void OnEnable()
        {
            StartCoroutine(SelfDestruct());
        }

        private void OnDisable()
        {
            Debug.Log("Reset drone");
        }

        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(2);
            ReturnToPool();
        }
        
        private void ReturnToPool()
        {
            pool.Release(this);
        }

        public void Attack()
        {
            Debug.Log("Attack player");
        }
    }
}