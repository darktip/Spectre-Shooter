using System;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace UI
{
    public class WeaponSelectionPanel : MonoBehaviour
    {
        [SerializeField] private Image weaponImage;

        private WeaponsController _weaponsController;

        private void OnDestroy()
        {
            _weaponsController.OnWeaponChange -= HandleWeaponChange;
        }

        public void Bind(WeaponsController weaponsController)
        {
            _weaponsController = weaponsController;
            _weaponsController.OnWeaponChange += HandleWeaponChange;
            HandleWeaponChange(weaponsController.CurrentProfile);
        }

        private void HandleWeaponChange(WeaponProfile profile)
        {
            if(!weaponImage)
                return;

            weaponImage.sprite = profile.Icon;
        }
    }
}
