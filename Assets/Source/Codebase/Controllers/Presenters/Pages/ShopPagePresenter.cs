using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Factories;

namespace Source.Codebase.Controllers.Presenters.Pages
{
    public class ShopPagePresenter : IPresenter
    {
        private readonly ShopPage _shopPage;
        private readonly ShopPageView _view;
        private readonly WalletFactory _walletFactory;
        private readonly ItemScrollFactory _itemScrollFactory;

        public ShopPagePresenter(
            ShopPage shopPage,
            ShopPageView view,
            WalletFactory walletFactory,
            ItemScrollFactory itemScrollFactory)
        {
            _shopPage = shopPage;
            _view = view;
            _walletFactory = walletFactory;
            _itemScrollFactory = itemScrollFactory;
        }

        public void Enable()
        {
            _walletFactory.Create(_view.transform);
            _itemScrollFactory.Create(_view.transform);
        }

        public void Disable() { }
    }
}
