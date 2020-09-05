using System;
using Patterns.Singleton;
using Stats;
using UnityEngine;
using Weapons;

namespace Gameplay
{
    public class PlayerInfo : Singleton<PlayerInfo>
    {
        public Transform PlayerTransform => transform;
        public WeaponsController WeaponsController { get; private set; }

        public Health Health { get; private set; }

        private void OnEnable()
        {
            WeaponsController = GetComponentInChildren<WeaponsController>();
            Health = GetComponent<Health>();
        }
    }
}
