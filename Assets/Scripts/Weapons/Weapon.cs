using System;
using Patterns.ObjectPool;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform mufflePoint;
        [SerializeField] private WeaponProfile weaponProfile;

        private float _timer = 0f;
        private float _fireReadyTime;

        private void Awake()
        {
            _fireReadyTime = 1 / weaponProfile.FireRate;
        }

        private void OnEnable()
        {
            _timer = 0f;
        }

        public void Update()
        {
            _timer += Time.deltaTime;
        }

        public void Shoot()
        {
            if (_timer < _fireReadyTime)
                return;
            
            var bullet = PoolManager.Instance.GetPool(weaponProfile.ProjectilePrefab.gameObject).Get()
                .GetComponent<Projectile>();

            bullet.transform.position = mufflePoint.position;
            bullet.transform.rotation = mufflePoint.rotation;

            bullet.Init(weaponProfile.Damage);
            bullet.OnHitSomething += () =>
                PoolManager.Instance.GetPool(weaponProfile.ProjectilePrefab.gameObject)
                    .ReturnToPool(bullet.gameObject);

            _timer = 0f;
        }
    }
}