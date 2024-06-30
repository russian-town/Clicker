using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services;
using Source.Codebase.Services.Abstract;

namespace Source.Codebase.Controllers.Presenters
{
    public class ItemPresenter : IPresenter
    {
        private readonly Item _item;
        private readonly ItemView _view;
        private readonly ItemConfig _config;
        private readonly IProgressService _progressService;
        private readonly GameLoopService _gameLoopService;
        private readonly ShopService _shopService;

        public ItemPresenter(
            Item item,
            ItemView view, 
            ItemConfig config,
            IProgressService progressService,
            GameLoopService gameLoopService,
            ShopService shopService)
        {
            _item = item;
            _view = view;
            _config = config;
            _progressService = progressService;
            _gameLoopService = gameLoopService;
            _shopService = shopService;
        }

        public void Enable()
        {
            _view.SellButton.onClick.AddListener(OnSellButtonClicked);
            _item.DataReaded += OnDataReaded;
            _item.Bought += OnBought;
            UpdateView();
            string clickForceText = $"+ {_config.ClickForce}";
            _view.SetClickForceText(clickForceText);
            string priceText = _config.Price.ToString();
            _view.SetPriceText(priceText);
            _view.SetName(_config.Name);
            _view.SetIcon(_config.Icon);
        }

        public void Disable()
        {
            _view.SellButton.onClick.RemoveListener(OnSellButtonClicked);
            _item.DataReaded -= OnDataReaded;
            _item.Bought -= OnBought;
        } 

        private void UpdateView()
        {
            if (_item.IsBought)
                _view.DisableSellButton();
            else
                _view.EnableSellButton();
        }

        private void OnSellButtonClicked()
        {
            if (_shopService.TrySell(_config.Price))
            {
                _item.By();
                _gameLoopService.UpdateClickForce(_config.ClickForce);
                UpdateView();
            }
        }

        private void OnDataReaded()
            => UpdateView();

        private void OnBought()
            => _progressService.Save();
    }
}
