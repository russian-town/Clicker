using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services;
using Source.Codebase.Services.Factories;

namespace Source.Codebase.Controllers.Presenters
{
    public class ItemScrollPresenter : IPresenter
    {
        private readonly ItemScroll _itemScroll;
        private readonly ItemSctollView _view;
        private readonly ItemFactory _viewFactory;
        private readonly ItemConfig[] _itemConfigs;

        public ItemScrollPresenter(
            ItemScroll itemScroll,
            ItemSctollView view,
            ItemFactory viewFactory,
            ItemConfig[] itemConfigs)
        {
            _itemScroll = itemScroll;
            _view = view;
            _viewFactory = viewFactory;
            _itemConfigs = itemConfigs;
        }

        public void Enable()
        {
            foreach (var itemConfig in _itemConfigs)
            {
                _viewFactory.Create(itemConfig, _view.Content);
            }
        }

        public void Disable() { }
    }
}
