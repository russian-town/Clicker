using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class PageScrollPresenter : IPresenter
    {
        private readonly PageScroll _scroll;
        private readonly PageScrollView _view;
        private readonly ScrollService _scrollService;

        public PageScrollPresenter(
            PageScroll scroll,
            PageScrollView view,
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
                .35f,
                _scrollService.EndScroll);
        }
    }
}
