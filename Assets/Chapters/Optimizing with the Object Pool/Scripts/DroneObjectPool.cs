using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool 
{
    public class DroneObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;

        public IObjectPool<Drone> Pool 
        {
            get 
            {
                if (_pool == null)
                    _pool = 
                        new ObjectPool<Drone>(
                            CreatedPooledItem, 
                            OnTakeFromPool, 
                            OnReturnedToPool, 
                            OnDestroyPoolObject, 
                            true, 
                            5, 
                            maxPoolSize);
                return _pool;
            }
        }

        private IObjectPool<Drone> _pool;

        private Drone CreatedPooledItem() 
        {
            var go = 
                GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            Drone drone = go.AddComponent<Drone>();
            
            go.name = "Drone";
            drone.pool = Pool;
            
            return drone;
        }

        private void OnReturnedToPool(Drone system) 
        {
            system.gameObject.SetActive(false);
        }

        private void OnTakeFromPool(Drone system) 
        {
            system.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject(Drone system) 
        {
            Destroy(system.gameObject);
        }

        public void Spawn() 
        {
            var amount = Random.Range(1, 10);
            
            for (int i = 0; i < amount; ++i) {
                var drone = Pool.Get();
                
                drone.transform.position = 
                    Random.insideUnitSphere * 10;
                
                drone.Attack();
            }
        }
    }
}