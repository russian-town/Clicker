using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Services;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.Factories;
using VContainer.Unity;

namespace Source.Codebase.Infrastructure
{
    public class EntryPoint : IInitializable, IDataReader
    {
        private readonly StaticDataService _staticDataService;
        private readonly GameConfig _gameConfig;
        private readonly ISaveLoadService _saveLoadService;
        private readonly HUDFactory _hudFactory;
        private readonly ProgressService _progressService;

        public EntryPoint(
            StaticDataService staticDataService,
            GameConfig gameConfig,
            ISaveLoadService saveLoadService,
            HUDFactory hudFactory,
            ProgressService progressService)
        {
            _staticDataService = staticDataService;
            _gameConfig = gameConfig;
            _saveLoadService = saveLoadService;
            _hudFactory = hudFactory;
            _progressService = progressService;
        }

        public void Initialize()
        {
            _staticDataService.LoadGameConfig(_gameConfig);
            _saveLoadService.AddIDataReader(this);
            _hudFactory.Create();
            _saveLoadService.Load();
        }

        public void Read(PlayerData playerData)
            => _progressService.SetPlayerData(playerData);
    }
}
