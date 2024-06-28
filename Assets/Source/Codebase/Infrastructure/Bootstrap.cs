using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Codebase.Infrastructure
{
    public class Bootstrap : MonoBehaviour, IDataReader
    {
        private const string GameScene = "Game";

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

            _playerData = new()
            {
                NeedClickPerNextLevel = 10,
                CurrentLevel = 1,
                CurrentClickForce = 1,
                LastClickCount = 0
            };

            _saveLoadService.Save(_playerData);
            SceneManager.LoadScene(GameScene);
        }

        public void Read(PlayerData playerData)
            => _playerData = playerData;
    }
}
