using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 50)]
    public class WeaponProfile : ScriptableObject
    {
        [SerializeField] private Weapon weaponPrefab;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float damage;
        [SerializeField] private float fireRate;
        [SerializeField] private Sprite icon;

        public GameObject WeaponPrefab => weaponPrefab.gameObject;
        public Projectile ProjectilePrefab => projectilePrefab;
        public float Damage => damage;
        public float FireRate => fireRate;
        public Sprite Icon => icon;
    }
}
