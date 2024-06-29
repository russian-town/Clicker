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

        public ClickHandlerPresenter(
            ClickHandler clickHandler,
            ClickHandlerView clickHandlerView,
            ClickEffectFactory effectFactory,
            GameLoopService gameLoopService,
            Camera camera)
        {
            _clickHandler = clickHandler;
            _view = clickHandlerView;
            _effectFactory = effectFactory;
            _gameLoopService = gameLoopService;
            _camera = camera;
        }

        public void Enable()
        {
            _view.Clicked += OnClicked;
            _clickHandler.ClickForceUpdated += OnClickForceUpdated;
            OnClickForceUpdated();
        }

        public void Disable()
        {
            _view.Clicked -= OnClicked;
            _clickHandler.ClickForceUpdated -= OnClickForceUpdated;
        }

        private void OnClickForceUpdated()
            => _gameLoopService.UpdateClickForce(_clickHandler.ClickForce);

        private void OnClicked(Vector2 screenPosition)
        {
            Vector2 worldPosition = _camera.ScreenToWorldPoint(screenPosition);
            _effectFactory.Create(_clickHandler.ClickForce, worldPosition);
            _gameLoopService.HandleClick(_clickHandler.ClickForce);
        }
    }
}
