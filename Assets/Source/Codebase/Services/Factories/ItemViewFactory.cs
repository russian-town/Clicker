using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class ItemViewFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IProgressService _progressService;
        private readonly GameLoopService _gameLoopService;

        public ItemViewFactory(
            IStaticDataService staticDataService,
            IProgressService progressService,
            GameLoopService gameLoopService)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _gameLoopService = gameLoopService;
        }

        public void Create(Item item, Transform parent, ShopService shopService)
        {
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
                shopService);
            view.Construct(itemPresenter);
        }
    }
}
