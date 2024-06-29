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

        public ItemViewFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Create(Item item, Transform parent)
        {
            ItemConfig config = _staticDataService.GetItemConfig(item.ClickType);
            ItemView itemViewTemplate =
                _staticDataService.GetViewTemplate<ItemView>();
            ItemView view =
                Object.Instantiate(itemViewTemplate, parent);
            ItemPresenter itemPresenter = new(item, view, config);
            view.Construct(itemPresenter);
        }
    }
}
