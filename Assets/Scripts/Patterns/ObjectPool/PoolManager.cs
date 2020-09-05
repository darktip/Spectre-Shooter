using System;
using System.Collections.Generic;
using Patterns.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Patterns.ObjectPool
{
    public class PoolManager : Singleton<PoolManager>
    {
        private readonly Dictionary<int, ObjectPool> _objectPools = new Dictionary<int, ObjectPool>();
        
        private void Awake()
        {
            SceneManager.activeSceneChanged += (s1, s2) =>
            {
                foreach (var pool in _objectPools.Values)
                {
                    pool.ReturnToPoolAll();
                }
            };
        }

        public ObjectPool CreatePool(int initialCapacity, GameObject pooledObject)
        {
            int key = pooledObject.GetInstanceID();

            if (!_objectPools.ContainsKey(key))
            {
                var newPool = new ObjectPool(initialCapacity, pooledObject);
                _objectPools[key] = newPool;
                
                DontDestroyOnLoad(newPool.PoolRoot);
            }

            return _objectPools[key];
        }

        public ObjectPool GetPool(GameObject pooledObject)
        {
            int key = pooledObject.GetInstanceID();

            if (!_objectPools.ContainsKey(key))
                CreatePool(1, pooledObject);
            
            return _objectPools[key];
        }
    }
}