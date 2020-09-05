using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Patterns.ObjectPool
{
    public class ObjectPool
    {
        private readonly Queue<GameObject> _pool;

        private List<GameObject> _notInPoolObjects;
        
        private readonly GameObject _pooledObject;

        private readonly Transform _poolParent;
        
        public GameObject PoolRoot => _poolParent.gameObject;
        
        public ObjectPool(int initialCapacity, GameObject pooledObject)
        {
            _pool = new Queue<GameObject>();
            _notInPoolObjects = new List<GameObject>();
            _pooledObject = pooledObject;
            _poolParent = new GameObject($"Pool of {pooledObject.name}").transform;
            
            AddToPool(initialCapacity);
        }

        private void AddToPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var obj = Object.Instantiate(_pooledObject, _poolParent);
                obj.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(_poolParent);
            _pool.Enqueue(obj);
            _notInPoolObjects.Remove(obj);
        }

        public void ReturnToPoolAll()
        {
            while (_notInPoolObjects.Count > 0)
            {
                ReturnToPool(_notInPoolObjects.First());
            }
        }

        public GameObject Get()
        {
            if (_pool.Count == 0)
                AddToPool(1);

            var obj = _pool.Dequeue();
            obj.SetActive(true);

            _notInPoolObjects.Add(obj);
            
            return obj;
        }
    }
}
