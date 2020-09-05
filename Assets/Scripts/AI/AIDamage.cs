using System;
using Stats;
using UnityEngine;

namespace AI
{
    public class AIDamage : MonoBehaviour
    {
        [SerializeField] private float damageRate;

        private void OnTriggerStay(Collider other)
        {
            var health = other.GetComponent<Health>();

            if (health)
            {
                health.Damage(damageRate * Time.deltaTime);
            }
        }
    }
}
