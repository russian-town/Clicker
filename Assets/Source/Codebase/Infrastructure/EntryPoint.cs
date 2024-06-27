using Source.Codebase.Domain.Configs;
using Source.Codebase.Services;
using VContainer.Unity;

namespace Source.Codebase.Infrastructure
{
    public class EntryPoint : IInitializable
    {
        private readonly StaticDataService _staticDataService;
        private readonly ClickHandlerFactory _clickHandlerFactory;
        private readonly LevelFactory _levelFactory;
        private readonly LevelProgressBarFactory _levelProgressBarFactory;
        private readonly GameConfig _gameConfig;

        public EntryPoint(
            StaticDataService staticDataService,
            ClickHandlerFactory clickHandlerFactory,
            LevelFactory levelFactory,
            LevelProgressBarFactory levelProgressBarFactory,
            GameConfig gameConfig)
        {
            _staticDataService = staticDataService;
            _clickHandlerFactory = clickHandlerFactory;
            _levelFactory = levelFactory;
            _levelProgressBarFactory = levelProgressBarFactory;
            _gameConfig = gameConfig;
        }

        public void Initialize()
        {
            _staticDataService.LoadGameConfig(_gameConfig);
            _levelFactory.Create();
            _clickHandlerFactory.Create();
            _levelProgressBarFactory.Create(10);
        }
    }
}
