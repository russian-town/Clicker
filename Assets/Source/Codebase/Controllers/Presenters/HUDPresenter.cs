using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Factories;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class HUDPresenter : IPresenter
    {
        private readonly HUD _hud;
        private readonly HUDView _view;
        private readonly PageConfig[] _pageConfigs;
        private readonly PageFactory _pageFactory;
        private readonly PageButtonFactory _pageButtonFactory;

        public HUDPresenter(
            HUD hud,
            HUDView view,
            PageConfig[] pageConfigs,
            PageFactory pageFactory,
            PageButtonFactory pageButtonFactory,
            Camera camera)
        {
            _hud = hud;
            _view = view;
            _pageConfigs = pageConfigs;
            _pageFactory = pageFactory;
            _pageButtonFactory = pageButtonFactory;
            _view.Canvas.worldCamera = camera;
        }

        public void Enable()
        {
            foreach (var pageConfig in _pageConfigs)
            {
                _pageFactory.Create(pageConfig.PageIndex, _view.PageHolder);
                _pageButtonFactory.Create(pageConfig.PageIndex, _view.ButtonGroup);
            }
        }

        public void Disable()
        {
        }
    }
}
