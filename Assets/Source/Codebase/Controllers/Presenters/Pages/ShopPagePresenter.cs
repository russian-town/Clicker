using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Factories;
using Source.Codebase.Services.UI;

namespace Source.Codebase.Controllers.Presenters.Pages
{
    public class ShopPagePresenter : IPresenter
    {
        private readonly ShopPage _shopPage;
        private readonly ShopPageView _view;
        private readonly WalletFactory _walletFactory;
        private readonly ItemScrollFactory _itemScrollFactory;
        private readonly PageScrollService _scrollService;

        public ShopPagePresenter(
            ShopPage shopPage,
            ShopPageView view,
            WalletFactory walletFactory,
            ItemScrollFactory itemScrollFactory,
            PageScrollService scrollService)
        {
            _shopPage = shopPage;
            _view = view;
            _walletFactory = walletFactory;
            _itemScrollFactory = itemScrollFactory;
            _scrollService = scrollService;
        }

        public void Enable()
        {
            _walletFactory.Create(_view.transform);
            _itemScrollFactory.Create(_view.transform);
            _view.Button.AddListener(Scroll);
            _scrollService.ScrollEnded += OnScrollEnded;
        }

        public void Disable()
        {
            _view.Button.RemoveListener(Scroll);
            _scrollService.ScrollEnded -= OnScrollEnded;
        }

        private void Scroll()
        {
            if (_scrollService.ActivPage == _shopPage.PageIndex)
                return;

            _scrollService.ScrollTo(_view.transform, _shopPage.PageIndex);
        }

        private void OnScrollEnded()
        {
            if(_scrollService.ActivPage != _shopPage.PageIndex)
            {
                _view.Button.Enable();
                return;
            }

            _view.Button.Disable();
        }
    }
}
