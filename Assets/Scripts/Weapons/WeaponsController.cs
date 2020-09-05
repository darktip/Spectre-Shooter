using System;
using System.Collections.Generic;
using GameInput;
using UnityEngine;

namespace Weapons
{
    public class WeaponsController : MonoBehaviour
    {
        [SerializeField] private List<WeaponProfile> weaponProfiles;

        private List<Weapon> _weapons;
        
        private int _currentWeaponIndex;

        public WeaponProfile CurrentProfile => weaponProfiles[_currentWeaponIndex];
        
        public event Action<WeaponProfile> OnWeaponChange;
        
        private void Awake()
        {
            _weapons = new List<Weapon>();
            
            foreach (var weapon in weaponProfiles)
            {
                var obj = Instantiate(weapon.WeaponPrefab, transform);
                obj.SetActive(false);
                _weapons.Add(obj.GetComponent<Weapon>());
            }
        }

        private void Start()
        {
            ChangeWeapon(0);
        }

        private void ChangeWeapon(int index)
        {
            _weapons[_currentWeaponIndex].gameObject.SetActive(false);
            _weapons[index].gameObject.SetActive(true);

            _currentWeaponIndex = index;
            OnWeaponChange?.Invoke(weaponProfiles[index]);
        }

        public void Update()
        {
            if (InputManager.Instance.Input.Shoot())
            {
                _weapons[_currentWeaponIndex].Shoot();
            }

            if (InputManager.Instance.Input.WeaponChangeNext())
            {
                ChangeWeapon((int) Mathf.Repeat(_currentWeaponIndex + 1, _weapons.Count));
            }
            else if (InputManager.Instance.Input.WeaponChangePrevious())
            {
                ChangeWeapon((int) Mathf.Repeat(_currentWeaponIndex - 1, _weapons.Count));
            }
        }
    }
}
