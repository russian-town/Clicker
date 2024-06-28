using Source.Codebase.Domain.Configs;
using Source.Codebase.Services;
using Source.Codebase.Services.Abstract;
using VContainer.Unity;

namespace Source.Codebase.Infrastructure
{
    public class EntryPoint : IInitializable
    {
        private readonly StaticDataService _staticDataService;
        private readonly ClickHandlerFactory _clickHandlerFactory;
        private readonly LevelFactory _levelFactory;
        private readonly GameConfig _gameConfig;
        private readonly ISaveLoadService _saveLoadService;

        public EntryPoint(
            StaticDataService staticDataService,
            ClickHandlerFactory clickHandlerFactory,
            LevelFactory levelFactory,
            GameConfig gameConfig,
            ISaveLoadService saveLoadService)
        {
            _staticDataService = staticDataService;
            _clickHandlerFactory = clickHandlerFactory;
            _levelFactory = levelFactory;
            _gameConfig = gameConfig;
            _saveLoadService = saveLoadService;
        }

        public void Initialize()
        {
            _staticDataService.LoadGameConfig(_gameConfig);
            _levelFactory.Create();
            _clickHandlerFactory.Create();
            _saveLoadService.Load();
        }
    }
}
