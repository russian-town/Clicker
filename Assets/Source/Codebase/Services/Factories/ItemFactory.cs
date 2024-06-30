using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class ItemFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IProgressService _progressService;
        private readonly GameLoopService _gameLoopService;
        private readonly SaveLoadService _saveLoadService;
        private readonly ShopService _shopService;

        public ItemFactory(
            IStaticDataService staticDataService,
            IProgressService progressService,
            GameLoopService gameLoopService,
            SaveLoadService saveLoadService,
            ShopService shopService)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _gameLoopService = gameLoopService;
            _saveLoadService = saveLoadService;
            _shopService = shopService;
        }

        public void Create(ItemConfig itemConfig, Transform parent)
        {
            Item item = new(itemConfig);
            _saveLoadService.AddIDataReader(item);
            _saveLoadService.AddIDataWriter(item);
            ItemConfig config = _staticDataService.GetItemConfig(item.ClickType);
            ItemView itemViewTemplate =
                _staticDataService.GetViewTemplate<ItemView>();
            ItemView view =
                Object.Instantiate(itemViewTemplate, parent);
            ItemPresenter itemPresenter = new(
                item,
                view,
                config,
                _progressService,
                _gameLoopService,
                _shopService);
            view.Construct(itemPresenter);
        }
    }
}
