using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class HUDFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly PageConfig[] _pageConfigs;
        private readonly PageFactory _pageFactory;
        private readonly PageButtonFactory _pageButtonFactory;
        private readonly Camera _camera;

        public HUDFactory(
            IStaticDataService staticDataService,
            PageConfig[] pageConfigs,
            PageFactory pageFactory,
            PageButtonFactory pageButtonFactory,
            Camera camera)
        {
            _staticDataService = staticDataService;
            _pageConfigs = pageConfigs;
            _pageFactory = pageFactory;
            _pageButtonFactory = pageButtonFactory;
            _camera = camera;
        }

        public void Create()
        {
            HUD hud = new();
            HUDView template =
                _staticDataService.GetViewTemplate<HUDView>();
            HUDView view = Object.Instantiate(template);
            HUDPresenter presenter = new(
                hud,
                view,
                _staticDataService,
                _pageConfigs,
                _pageFactory,
                _pageButtonFactory,
                _camera);
            view.Construct(presenter);
        }
    }
}
