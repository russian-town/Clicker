using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.Factories;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class HUDPresenter : IPresenter
    {
        private readonly HUD _hud;
        private readonly HUDView _view;
        private readonly IStaticDataService _staticDataService;
        private readonly PageConfig[] _pageConfigs;
        private readonly PageFactory _pageFactory;
        private readonly PageButtonFactory _pageButtonFactory;
        private readonly ScrollService _scrollService;

        private PageScrollView _pageScrollView;

        public HUDPresenter(
            HUD hud,
            HUDView view,
            IStaticDataService staticDataService,
            PageConfig[] pageConfigs,
            PageFactory pageFactory,
            PageButtonFactory pageButtonFactory,
            Camera camera)
        {
            _hud = hud;
            _view = view;
            _staticDataService = staticDataService;
            _pageConfigs = pageConfigs;
            _pageFactory = pageFactory;
            _pageButtonFactory = pageButtonFactory;
            _scrollService = new();
            _view.Canvas.worldCamera = camera;
        }

        public void Enable()
        {
            PageScroll pageScroll = new();
            PageScrollView template =
                _staticDataService.GetViewTemplate<PageScrollView>();
            _pageScrollView = Object.Instantiate(template, _view.transform);
            PageScrollPresenter pageScrollPresenter =
                new(pageScroll, _pageScrollView, _scrollService);
            _pageScrollView.Construct(pageScrollPresenter);

            foreach (var pageConfig in _pageConfigs)
            {
                _pageFactory.Create(
                    _pageScrollView.Container,
                    pageConfig);
                _pageButtonFactory.Create(
                    pageConfig.PageIndex,
                    _view.ButtonGroup,
                    _scrollService);
            }
        }

        public void Disable() { }
    }
}
