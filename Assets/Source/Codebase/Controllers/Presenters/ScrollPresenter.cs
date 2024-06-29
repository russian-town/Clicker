using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class ScrollPresenter : IPresenter
    {
        private readonly Scroll _scroll;
        private readonly ScrollView _view;
        private readonly ScrollService _scrollService;

        public ScrollPresenter(
            Scroll scroll,
            ScrollView view,
            ScrollService scrollService)
        {
            _scroll = scroll;
            _view = view;
            _scrollService = scrollService;
        }

        public void Enable()
            => _scrollService.Scrolled += OnScrolled;

        public void Disable()
            => _scrollService.Scrolled -= OnScrolled;

        private void OnScrolled(Transform target)
        {
            Vector2 targetPostion =
                new(target.localPosition.x, target.localPosition.y);
            _view.StartMoveAnimation(
                targetPostion,
                _scroll.MoveDuration, 
                _scrollService.EndScroll);
        }
    }
}
