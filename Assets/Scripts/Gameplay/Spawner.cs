using System;
using Patterns.ObjectPool;
using Stats;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] spawnObjects;
        
        [SerializeField] private int maxSpawnedObjects;
        [SerializeField] private float minSpawnDelay;
        [SerializeField] private float maxSpawnDelay;

        [SerializeField] private Vector2 spawnArea;
        
        private int _spawnedObjCount = 0;

        private float _timer = 0f;
        private float _nextSpawnDelay = 0f;

        private void Start()
        {
            UpdateDelay();
        }

        void Update()
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _nextSpawnDelay && _spawnedObjCount < maxSpawnedObjects)
            {
                Spawn();
                
                UpdateDelay();
                _timer = 0f;
            }
        }

        private void Spawn()
        {
            var ranObj = GetRandomObject();
            var ghost = PoolManager.Instance.GetPool(ranObj).Get();
            ghost.transform.position = GetRandomSpawnPosition();
                
            ghost.GetComponent<Health>().OnDeath +=
                health =>
                {
                    PoolManager.Instance.GetPool(ranObj).ReturnToPool(ghost);
                    _spawnedObjCount--;
                };

            _spawnedObjCount++;
        }

        protected virtual GameObject GetRandomObject()
        {
            return spawnObjects[Random.Range(0, spawnObjects.Length)];
        }

        protected virtual Vector3 GetRandomSpawnPosition()
        {
            float rand = Random.Range(0, 2 * (spawnArea.x + spawnArea.y));
            Vector2 randPoint;
            
            if (rand <= spawnArea.x)
                randPoint = new Vector2(rand - spawnArea.x / 2, spawnArea.y / 2);
            else if (rand <= spawnArea.x + spawnArea.y)
                randPoint = new Vector2(spawnArea.x / 2, spawnArea.y / 2 - (rand - spawnArea.x));
            else if (rand <= 2 * spawnArea.x + spawnArea.y)
                randPoint = new Vector2(spawnArea.x / 2 - (rand - (spawnArea.x + spawnArea.y)), -spawnArea.y / 2);
            else
                randPoint = new Vector2(-spawnArea.x / 2, (rand - (2 * spawnArea.x + spawnArea.y)) - spawnArea.y / 2);

            return new Vector3(randPoint.x, 0f, randPoint.y);
        }

        void UpdateDelay()
        {
            _nextSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea.x, 0.5f, spawnArea.y));
        }
    }
}
