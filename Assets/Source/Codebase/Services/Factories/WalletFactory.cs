using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class WalletFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly GameLoopService _gameLoopService;
        private readonly ProgressService _progressService;
        private readonly ShopService _shopService;

        public WalletFactory(
            IStaticDataService staticDataService,
            ISaveLoadService saveLoadService,
            GameLoopService gameLoopService,
            ProgressService progressService,
            ShopService shopService)
        {
            _staticDataService = staticDataService;
            _saveLoadService = saveLoadService;
            _gameLoopService = gameLoopService;
            _progressService = progressService;
            _shopService = shopService;
        }

        public void Create(Transform parent)
        {
            Wallet wallet = new();
            _saveLoadService.AddIDataReader(wallet);
            _saveLoadService.AddIDataWriter(wallet);
            WalletView walletViewTemplate =
                _staticDataService.GetViewTemplate<WalletView>();
            _shopService.SetWallet(wallet);
            WalletView walletView =
                Object.Instantiate(walletViewTemplate, parent);
            WalletPresenter walletPresenter = new(
                wallet,
                walletView,
                _gameLoopService,
                _progressService,
                _shopService);
            walletView.Construct(walletPresenter);
        }
    }
}
