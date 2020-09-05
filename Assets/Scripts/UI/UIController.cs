using System;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private WeaponSelectionPanel weaponSelectionPanel;

        private void Awake()
        {
            weaponSelectionPanel.Bind(PlayerInfo.Instance.WeaponsController);
        }
    }
}
