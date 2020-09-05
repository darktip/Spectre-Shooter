using System;
using Gameplay;
using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeathScreenPanel : MonoBehaviour
    {
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            gameObject.SetActive(false);
            PlayerInfo.Instance.Health.OnDeath += OnPlayerDeath;
            restartButton.onClick.AddListener(() => GameController.Instance.Restart());
        }

        private void OnPlayerDeath(Health health)
        {
            gameObject.SetActive(true);
            PlayerInfo.Instance.Health.OnDeath -= OnPlayerDeath;
        }
    }
}
