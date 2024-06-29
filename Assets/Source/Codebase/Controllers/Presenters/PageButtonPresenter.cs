using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class PageButtonPresenter : IPresenter
    {
        private readonly PageButton _pageButton;
        private readonly PageButtonView _view;
        private readonly PageConfig _config;
        private readonly ScrollService _scrollService;
        private readonly PageService _pageService;

        public PageButtonPresenter(
            PageButton pageButton,
            PageButtonView view,
            PageConfig config,
            ScrollService scrollService,
            PageService pageService)
        {
            _pageButton = pageButton;
            _view = view;
            _config = config;
            _scrollService = scrollService;
            _pageService = pageService;

        }

        public void Enable()
        {
            _view.Button.onClick.AddListener(OnButtonClicked);
            _view.SetIcon(_config.ButtonIcon);
        }

        public void Disable()
        {
            _view.Button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            Transform target = _pageService.GetPageByIndex(_config.PageIndex);
            _scrollService.ScrollTo(target);
        }
    }
}
