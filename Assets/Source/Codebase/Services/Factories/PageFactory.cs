using System;
using Object = UnityEngine.Object;
using Source.Codebase.Controllers.Presenters.Pages;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class PageFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly PageService _pageService;
        private readonly LevelFactory _levelFactory;
        private readonly ClickHandlerFactory _clickHandlerFactory;
        private readonly ItemScrollFactory _itemScrollFactory;
        private readonly PopUpWindowFactory _popUpWindowFactory;
        private readonly WalletFactory _walletFactory;

        public PageFactory(
            IStaticDataService staticDataService,
            PageService pageService,
            LevelFactory levelFactory,
            ClickHandlerFactory clickHandlerFactory,
            ItemScrollFactory itemScrollFactory,
            PopUpWindowFactory popUpWindowFactory,
            WalletFactory walletFactory)
        {
            _staticDataService = staticDataService;
            _pageService = pageService;
            _levelFactory = levelFactory;
            _clickHandlerFactory = clickHandlerFactory;
            _itemScrollFactory = itemScrollFactory;
            _popUpWindowFactory = popUpWindowFactory;
            _walletFactory = walletFactory;
        }

        public void Create(Transform parent, PageConfig config)
        {
            switch (config.PageIndex)
            {
                case PageIndex.None:
                    throw new Exception("Page is None!");
                case PageIndex.Home:
                    CreateStartPage(config.PageIndex, parent);
                    break;
                case PageIndex.Shop:
                    CreateShopPage(config.PageIndex, parent);
                    break;
                case PageIndex.News:
                    CreateNewsPage(config.PageIndex, parent);
                    break;
            }
        }

        private void CreateStartPage(PageIndex index, Transform parent)
        {
            StartPage page = new();
            StartPageView template =
                _staticDataService.GetViewTemplate<StartPageView>();
            StartPageView view = Object.Instantiate(template, parent);
            _pageService.RegistrePage(index, view.transform);
            StartPagePresenter presenter =
                new(page, view, _levelFactory, _clickHandlerFactory);
            view.Construct(presenter);
        }

        private void CreateShopPage(PageIndex index, Transform parent)
        {
            ShopPage page = new();
            ShopPageView template =
                _staticDataService.GetViewTemplate<ShopPageView>();
            ShopPageView view = Object.Instantiate(template, parent);
            _pageService.RegistrePage(index, view.transform);
            ShopPagePresenter presenter =
                new(page, view, _walletFactory, _itemScrollFactory);
            view.Construct(presenter);
        }

        private void CreateNewsPage(PageIndex index, Transform parent)
        {
            NewsPage page = new();
            NewsPageView template =
                _staticDataService.GetViewTemplate<NewsPageView>();
            NewsPageView view = Object.Instantiate(template, parent);
            _pageService.RegistrePage(index, view.transform);
            NewsPagePresenter presenter =
                new(page, view, _popUpWindowFactory);
            view.Construct(presenter);
        }
    }
}
