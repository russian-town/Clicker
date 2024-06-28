using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class ClickHandlerFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ClickEffectFactory _clickEffectFactory;
        private readonly GameLoopService _gameLoopService;
        private readonly Transform _parent;
        private readonly Camera _camera;

        public ClickHandlerFactory(
            IStaticDataService staticDataService,
            ClickEffectFactory clickEffectFactory,
            GameLoopService gameLoopService,
            Transform parent,
            Camera camera)
        {
            _staticDataService = staticDataService;
            _clickEffectFactory = clickEffectFactory;
            _gameLoopService = gameLoopService;
            _parent = parent;
            _camera = camera;
        }

        public void Create()
        {
            ClickHandler clickHandler = new();
            ClickHandlerView template =
                _staticDataService.GetViewTemplate<ClickHandlerView>();
            ClickHandlerView view = Object.Instantiate(template, _parent);
            ClickHandlerPresenter presenter =
                new(clickHandler, view, _clickEffectFactory, _gameLoopService, _camera);
            view.Construct(presenter);
        }
    }
}
