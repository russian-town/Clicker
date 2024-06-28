using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Presentation.Windows;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class ItemViewFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly UpgradeWindow _upgradeWindow;

        public ItemViewFactory(
            IStaticDataService staticDataService,
            UpgradeWindow upgradeWindow)
        {
            _staticDataService = staticDataService;
            _upgradeWindow = upgradeWindow;
        }

        public void Create(Item item)
        {
            ItemConfig config = _staticDataService.GetItemConfig(item.ClickType);
            ItemView itemViewTemplate =
                _staticDataService.GetViewTemplate<ItemView>();
            ItemView view =
                Object.Instantiate(itemViewTemplate, _upgradeWindow.ItemContainer);
            ItemPresenter itemPresenter = new(item, view, config);
            view.Construct(itemPresenter);
        }
    }
}
