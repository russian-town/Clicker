using System;
using Object = UnityEngine.Object;
using Source.Codebase.Controllers.Presenters.Pages;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class PageFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly PageScrollService _scrollService;
        private readonly LevelFactory _levelFactory;
        private readonly ClickHandlerFactory _clickHandlerFactory;
        private readonly ItemScrollFactory _itemScrollFactory;
        private readonly PopUpWindowFactory _popUpWindowFactory;
        private readonly WalletFactory _walletFactory;
        private readonly PopUpWindowConfig[] _popUpWindowConfigs;

        public PageFactory(
            IStaticDataService staticDataService,
            PageScrollService scrollService,
            LevelFactory levelFactory,
            ClickHandlerFactory clickHandlerFactory,
            ItemScrollFactory itemScrollFactory,
            PopUpWindowFactory popUpWindowFactory,
            WalletFactory walletFactory,
            PopUpWindowConfig[] popUpWindowConfigs)
        {
            _staticDataService = staticDataService;
            _scrollService = scrollService;
            _levelFactory = levelFactory;
            _clickHandlerFactory = clickHandlerFactory;
            _itemScrollFactory = itemScrollFactory;
            _popUpWindowFactory = popUpWindowFactory;
            _walletFactory = walletFactory;
            _popUpWindowConfigs = popUpWindowConfigs;
        }

        public void Create(
            Transform parent,
            PageConfig config,
            Transform buttonGroup)
        {
            switch (config.PageIndex)
            {
                case PageIndex.None:
                    throw new Exception("Page is None!");
                case PageIndex.Home:
                    CreateStartPage(config, parent, buttonGroup);
                    break;
                case PageIndex.Shop:
                    CreateShopPage(config, parent, buttonGroup);
                    break;
                case PageIndex.News:
                    CreateNewsPage(config, parent, buttonGroup);
                    break;
            }
        }

        private void CreateStartPage(
            PageConfig config,
            Transform parent,
            Transform buttonGroup)
        {
            PageButtonView pageButton =
                GetPageButtonView(buttonGroup, config);
            StartPage page = new(config);
            StartPageView template =
                _staticDataService.GetViewTemplate<StartPageView>();
            StartPageView view = Object.Instantiate(template, parent);
            view.SetButton(pageButton);
            StartPagePresenter presenter =
                new(page, view, _levelFactory, _clickHandlerFactory, _scrollService);
            view.Construct(presenter);
        }

        private void CreateShopPage(
            PageConfig config,
            Transform parent,
            Transform buttonGroup)
        {
            PageButtonView pageButton =
                GetPageButtonView(buttonGroup, config);
            ShopPage page = new(config);
            ShopPageView template =
                _staticDataService.GetViewTemplate<ShopPageView>();
            ShopPageView view = Object.Instantiate(template, parent);
            view.SetButton(pageButton);
            ShopPagePresenter presenter =
                new(page, view, _walletFactory, _itemScrollFactory, _scrollService);
            view.Construct(presenter);
        }

        private void CreateNewsPage(
            PageConfig config,
            Transform parent,
            Transform buttonGroup)
        {
            PageButtonView pageButton =
                GetPageButtonView(buttonGroup, config);
            NewsPage page = new(config);
            NewsPageView template =
                _staticDataService.GetViewTemplate<NewsPageView>();
            NewsPageView view = Object.Instantiate(template, parent);
            view.SetButton(pageButton);
            NewsPagePresenter presenter = new(
                page,
                view,
                _popUpWindowFactory,
                _scrollService,
                _popUpWindowConfigs);
            view.Construct(presenter);
        }

        private PageButtonView GetPageButtonView(
            Transform buttonGroup,
            PageConfig config)
        {
            PageButtonView template =
                _staticDataService.GetViewTemplate<PageButtonView>();
            PageButtonView view =
                Object.Instantiate(template, buttonGroup);
            view.SetIcon(config.ButtonIcon);
            return view;
        }
    }
}
