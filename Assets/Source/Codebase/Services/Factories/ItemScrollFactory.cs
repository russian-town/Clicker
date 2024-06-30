using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class ItemScrollFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ItemFactory _itemFactory;
        private readonly ItemConfig[] _itemConfigs;

        public ItemScrollFactory(
            IStaticDataService staticDataService,
            ItemFactory itemFactory,
            ItemConfig[] itemConfigs)
        {
            _staticDataService = staticDataService;
            _itemFactory = itemFactory;
            _itemConfigs = itemConfigs;
        }

        public void Create(Transform parent)
        {
            ItemScroll itemScroll = new();
            ItemSctollView template =
                _staticDataService.GetViewTemplate<ItemSctollView>();
            ItemSctollView view = Object.Instantiate(template, parent);
            ItemScrollPresenter presenter = new(
                itemScroll,
                view,
                _itemFactory,
                _itemConfigs);
            view.Construct(presenter);
        }
    }
}
