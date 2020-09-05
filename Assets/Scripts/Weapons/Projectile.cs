using System;
using Stats;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;

        public event Action OnHitSomething;

        private Rigidbody _rigidbody;

        private float _damage;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void OnDisable()
        {
            OnHitSomething = null;
        }

        private void OnCollisionEnter(Collision other)
        {
            Hit(other.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Hit(other.gameObject);
        }

        private void Hit(GameObject other)
        {
            var health = other.gameObject.GetComponent<Health>();

            if (health)
            {
                health.Damage(_damage);
            }

            OnHitSomething?.Invoke();
        }

        public void Init(float damage)
        {
            _damage = damage;
            _rigidbody.velocity = transform.forward * speed;
        }
    }
}
