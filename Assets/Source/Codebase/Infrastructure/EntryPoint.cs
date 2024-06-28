using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Services;
using Source.Codebase.Services.Abstract;
using VContainer.Unity;

namespace Source.Codebase.Infrastructure
{
    public class EntryPoint : IInitializable, IDataReader
    {
        private readonly StaticDataService _staticDataService;
        private readonly ClickHandlerFactory _clickHandlerFactory;
        private readonly LevelFactory _levelFactory;
        private readonly GameConfig _gameConfig;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ItemFactory _itemFactory;
        private readonly ItemViewFactory _itemViewFactory;

        private SaveDataInjector _saveDataInjector;

        public EntryPoint(
            StaticDataService staticDataService,
            ClickHandlerFactory clickHandlerFactory,
            LevelFactory levelFactory,
            GameConfig gameConfig,
            ISaveLoadService saveLoadService,
            ItemFactory itemFactory,
            ItemViewFactory itemViewFactory,
            SaveDataInjector saveDataInjector)
        {
            _staticDataService = staticDataService;
            _clickHandlerFactory = clickHandlerFactory;
            _levelFactory = levelFactory;
            _gameConfig = gameConfig;
            _saveLoadService = saveLoadService;
            _itemFactory = itemFactory;
            _itemViewFactory = itemViewFactory;
            _saveDataInjector = saveDataInjector;
        }

        public void Initialize()
        {
            _saveLoadService.AddIDataReader(this);
            _staticDataService.LoadGameConfig(_gameConfig);
            _levelFactory.Create();
            _clickHandlerFactory.Create();
            _saveLoadService.Load();
            var items = _itemFactory.Get(_gameConfig.ItemConfigs);

            foreach (var item in items)
            {
                _saveDataInjector.Update(item);
            }

            foreach (var item in items)
            {
                _itemViewFactory.Create(item);
            }
        }

        public void Read(PlayerData playerData)
            => _saveDataInjector.SetData(playerData.ItemsData);
    }
}
