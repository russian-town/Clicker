using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class ClickHandlerPresenter : IPresenter
    {
        private readonly ClickHandler _clickHandler;
        private readonly ClickHandlerView _view;
        private readonly ClickEffectFactory _effectFactory;

        public ClickHandlerPresenter(
            ClickHandler clickHandler,
            ClickHandlerView clickHandlerView)
        {
            _clickHandler = clickHandler;
            _view = clickHandlerView;
        }

        public void Enable()
        {
            _view.Clicked += OnClicked;
        }

        public void Disable()
        {
            _view.Clicked -= OnClicked;
        }

        private void OnClicked(Vector2 position)
        {
            _effectFactory.Create(1, position);
        }
    }
}
