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
        private readonly PageScrollService _scrollService;

        public HUDPresenter(
            HUD hud,
            HUDView view,
            IStaticDataService staticDataService,
            PageConfig[] pageConfigs,
            PageFactory pageFactory,
            PageScrollService pageScrollService,
            Camera camera)
        {
            _hud = hud;
            _view = view;
            _staticDataService = staticDataService;
            _pageConfigs = pageConfigs;
            _pageFactory = pageFactory;
            _scrollService = pageScrollService;
            _view.Canvas.worldCamera = camera;
        }

        public void Enable()
        {
            PageScroll pageScroll = new();
            PageScrollView template =
                _staticDataService.GetViewTemplate<PageScrollView>();
            PageScrollView pageScrollView = Object.Instantiate(template, _view.transform);
            PageScrollPresenter pageScrollPresenter =
                new(pageScroll, pageScrollView, _scrollService);
            pageScrollView.Construct(pageScrollPresenter);

            foreach (var pageConfig in _pageConfigs)
            {
                _pageFactory.Create(
                    pageScrollView.Container,
                    pageConfig,
                    _view.ButtonGroup);
            }
        }

        public void Disable() { }
    }
}
