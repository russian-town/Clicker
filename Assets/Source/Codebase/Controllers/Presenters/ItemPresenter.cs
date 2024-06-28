using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;

namespace Source.Codebase.Controllers.Presenters
{
    public class ItemPresenter : IPresenter
    {
        private readonly Item _item;
        private readonly ItemView _view;
        private readonly ItemConfig _config;

        public ItemPresenter(
            Item item,
            ItemView view, 
            ItemConfig config)
        {
            _item = item;
            _view = view;
            _config = config;
        }

        public void Enable()
        {
            _view.SellButton.onClick.AddListener(OnSellButtonClicked);

            if(_item.IsBought)
                _view.DisableSellButton();
            else
                _view.EnableSellButton();

            string clickForceText = $"+ {_config.ClickForce}";
            _view.SetClickForceText(clickForceText);
            string priceText = _config.Price.ToString();
            _view.SetPriceText(priceText);
            _view.SetName(_config.Name);
            _view.SetIcon(_config.Icon);
        }

        public void Disable()
            => _view.SellButton.onClick.RemoveListener(OnSellButtonClicked);

        private void OnSellButtonClicked()
        {
        }
    }
}
