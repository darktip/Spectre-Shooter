using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float health;
        [SerializeField, Range(0f, 1f)] protected float defence;

        private float _currentHealth;

        public float GetHealth() => _currentHealth;
        public float GetDefence() => defence;
        public float GetMaxHealth() => health;

        public event Action<Health, float> OnGetDamage;
        public event Action<Health> OnDeath;

        private void OnEnable()
        {
            _currentHealth = health;
        }

        private void OnDisable()
        {
            OnDeath = null;
            OnGetDamage = null;
        }

        public void Damage(float damage)
        {
            float d = CalculateDamage(damage);
            _currentHealth -= d;

            OnGetDamage?.Invoke(this, d);
            if (_currentHealth <= 0) OnDeath?.Invoke(this);
        }

        protected virtual float CalculateDamage(float damage)
        {
            return damage * (1 - defence);
        }
    }
}