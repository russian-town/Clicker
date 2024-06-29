using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.Factories;
using Source.Codebase.Services.UI;
using UnityEngine;
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
        private readonly SaveDataInjector _saveDataInjector;
        private readonly HUDFactory _hudFactory;
        private readonly PageService _pageService;

        public EntryPoint(
            StaticDataService staticDataService,
            ClickHandlerFactory clickHandlerFactory,
            LevelFactory levelFactory,
            GameConfig gameConfig,
            ISaveLoadService saveLoadService,
            ItemFactory itemFactory,
            ItemViewFactory itemViewFactory,
            SaveDataInjector saveDataInjector,
            HUDFactory hudFactory,
            PageService pageService)
        {
            _staticDataService = staticDataService;
            _clickHandlerFactory = clickHandlerFactory;
            _levelFactory = levelFactory;
            _gameConfig = gameConfig;
            _saveLoadService = saveLoadService;
            _itemFactory = itemFactory;
            _itemViewFactory = itemViewFactory;
            _saveDataInjector = saveDataInjector;
            _hudFactory = hudFactory;
            _pageService = pageService;
        }

        public void Initialize()
        {
            _saveLoadService.AddIDataReader(this);
            _staticDataService.LoadGameConfig(_gameConfig);
            _hudFactory.Create();
            Transform startPage = _pageService.GetPageByIndex(PageIndex.Home);
            Transform shopPage = _pageService.GetPageByIndex(PageIndex.Shop);
            ScrollConfig scrollConfig =
                _staticDataService.GetScrollConfig(ScrollType.Item);
            Scroll scroll = new Scroll(scrollConfig);
            ScrollView scrollView =
                Object.Instantiate(scrollConfig.ScrollViewTemplate, shopPage);
            ScrollService scrollService = new();
            ScrollPresenter scrollPresenter =
                new(scroll, scrollView, scrollService);
            scrollView.Construct(scrollPresenter);
            _levelFactory.Create(startPage);
            _clickHandlerFactory.Create(startPage);
            _saveLoadService.Load();
            var items = _itemFactory.Get(_gameConfig.ItemConfigs);

            foreach (var item in items)
            {
                _saveDataInjector.Update(item);
            }

            foreach (var item in items)
            {
                _itemViewFactory.Create(item, scrollView.Container);
            }
        }

        public void Read(PlayerData playerData)
            => _saveDataInjector.SetData(playerData.ItemsData);
    }
}
