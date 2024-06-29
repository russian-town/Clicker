using Source.Codebase.Data;
using Source.Codebase.Services.Abstract;

namespace Source.Codebase.Services
{
    public class ProgressService : IProgressService
    {
        private readonly ISaveLoadService _saveLoadService;

        private PlayerData _playerData;

        public ProgressService(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void SetPlayerData(PlayerData playerData)
            => _playerData = playerData;

        public void Save()
            => _saveLoadService.Save(_playerData);
    }
}
