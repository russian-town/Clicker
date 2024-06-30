using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain;
using Source.Codebase.Presentation;
using Source.Codebase.Services;
using Source.Codebase.Services.Abstract;

namespace Source.Codebase.Controllers.Presenters
{
    public class WalletPresenter : IPresenter
    {
        private readonly Wallet _wallet;
        private readonly WalletView _view;
        private readonly GameLoopService _gameLoopService;
        private readonly IProgressService _progressService;
        private readonly ShopService _shopService;

        public WalletPresenter(
            Wallet wallet,
            WalletView view,
            GameLoopService gameLoopService,
            IProgressService progressService,
            ShopService shopService)
        {
            _wallet = wallet;
            _view = view;
            _gameLoopService = gameLoopService;
            _progressService = progressService;
            _shopService = shopService;
        }

        public void Enable()
        {
            _wallet.BalanceChanged += OnBalanceChanged;
            _gameLoopService.Clicked += OnClicked;
            _shopService.Selled += OnSelled;
        }

        public void Disable()
        {
            _wallet.BalanceChanged -= OnBalanceChanged;
            _gameLoopService.Clicked -= OnClicked;
            _shopService.Selled -= OnSelled;
            _progressService.Save();
        }

        private void OnBalanceChanged(int balance)
        {
            string balanceText = balance.ToString();
            _view.SetBalanceText(balanceText);
        }

        private void OnClicked(int clickForce)
            => _wallet.IncreaseBalance(clickForce);

        private void OnSelled(int price)
            => _wallet.DecreaseBalance(price);
    }
}
