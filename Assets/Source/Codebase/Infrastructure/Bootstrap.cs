using System.Collections.Generic;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Codebase.Infrastructure
{
    public class Bootstrap : MonoBehaviour, IDataReader
    {
        private const string GameScene = "Game";

        [SerializeField] private ItemConfig[] _itemConfigs;

        private SaveLoadService _saveLoadService;
        private PlayerData _playerData;

        public void Awake()
        {
            _saveLoadService = new();
            _saveLoadService.AddIDataReader(this);
            _saveLoadService.Load();

            if (_playerData != null)
            {
                SceneManager.LoadScene(GameScene);
                return;
            }

            List<ItemData> itemsData = new();

            foreach (var itemConfig in _itemConfigs)
            {
                ItemData itemData = new();
                itemData.IsBought = false;
                itemData.ClickType = itemConfig.ClickType;
                itemsData.Add(itemData);
            }

            _playerData = new()
            {
                NeedClickPerNextLevel = 10,
                CurrentLevel = 1,
                CurrentClickForce = 1,
                LastClickCount = 0,
                ItemsData = itemsData
            };

            _saveLoadService.Save(_playerData);
            SceneManager.LoadScene(GameScene);
        }

        public void Read(PlayerData playerData)
            => _playerData = playerData;
    }
}
