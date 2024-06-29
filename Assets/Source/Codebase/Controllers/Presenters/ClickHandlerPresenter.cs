using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services;
using Source.Codebase.Services.Factories;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class ClickHandlerPresenter : IPresenter
    {
        private readonly ClickHandler _clickHandler;
        private readonly ClickHandlerView _view;
        private readonly ClickEffectFactory _effectFactory;
        private readonly GameLoopService _gameLoopService;
        private readonly Camera _camera;
        private readonly Transform _parent;

        public ClickHandlerPresenter(
            ClickHandler clickHandler,
            ClickHandlerView clickHandlerView,
            ClickEffectFactory effectFactory,
            GameLoopService gameLoopService,
            Camera camera,
            Transform parent)
        {
            _clickHandler = clickHandler;
            _view = clickHandlerView;
            _effectFactory = effectFactory;
            _gameLoopService = gameLoopService;
            _camera = camera;
            _parent = parent;
        }

        public void Enable()
        {
            _view.Clicked += OnClicked;
            _gameLoopService.ClickForceUpdated += OnClickForceUpdated;
        }

        public void Disable()
        {
            _view.Clicked -= OnClicked;
            _gameLoopService.ClickForceUpdated -= OnClickForceUpdated;
        }

        private void OnClickForceUpdated(int clickForce)
        {
            if (_clickHandler.ClickForce > clickForce)
                return;

            _clickHandler.UpdateClickForce(clickForce);
        } 

        private void OnClicked(Vector2 screenPosition)
        {
            Vector2 worldPosition = _camera.ScreenToWorldPoint(screenPosition);
            _effectFactory.Create(
                _clickHandler.ClickForce,
                worldPosition,
                _parent);
            _gameLoopService.HandleClick(_clickHandler.ClickForce);
        }
    }
}
