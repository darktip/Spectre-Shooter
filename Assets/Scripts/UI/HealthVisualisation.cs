using System;
using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [DefaultExecutionOrder(50)]
    public class HealthVisualisation : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;

        private Health _health;
        private Camera _camera;

        private void Update()
        {
            healthBar.transform.LookAt(_camera.transform);
        }

        private void OnEnable()
        {
            _health = GetComponent<Health>();
            _camera = Camera.main;
            
            _health.OnGetDamage += OnHealthChange;
            OnHealthChange(_health, 0);
        }

        private void OnDisable()
        {
            _health.OnGetDamage -= OnHealthChange;
        }

        private void OnHealthChange(Health health, float damage)
        {
            healthBar.value = health.GetHealth() / health.GetMaxHealth();
        }
    }
}
