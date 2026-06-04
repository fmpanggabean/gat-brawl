using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPooling
{
    public abstract class ObjectPooling : MonoBehaviour
    {
        public ObjectPool<GameObject> Pool => pool;
        
        private ObjectPool<GameObject> pool;
        private int size;
        private GameObject prefab;

        public void Init(GameObject prefab,int size)
        {
            this.prefab = prefab;
            this.size = size;
            
            pool = new ObjectPool<GameObject>(
                () => Instantiate(prefab, transform)
                , ActionOnGet
                , ActionOnRelease
                , ActionOnDestroy
                , true, size, size * 10
                );
        }

        public void PreWarm()
        {
            var temp = new GameObject[size];
            
            for (var i = 0; i < size; i++)
            {
                temp[i] = pool.Get();
            }

            for (var i = 0; i < size; i++)
            {
                pool.Release(temp[i]);
            }
        }

        private void ActionOnDestroy(GameObject obj)
        {
            Destroy(obj);
        }

        private void ActionOnRelease(GameObject obj)
        {
            obj.SetActive(false);
        }

        private void ActionOnGet(GameObject obj)
        {
            obj.SetActive(true);
        }
    }
}
