using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Factories;
using Source.Codebase.Services.UI;
using System;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters.Pages
{
    public class StartPagePresenter : IPresenter
    {
        private readonly StartPage _startPage;
        private readonly StartPageView _view;
        private readonly LevelFactory _levelFactory;
        private readonly ClickHandlerFactory _clickHandlerFactory;
        private readonly PageScrollService _scrollService;

        public StartPagePresenter(
            StartPage startPage,
            StartPageView view,
            LevelFactory levelFactory,
            ClickHandlerFactory clickHandlerFactory,
            PageScrollService scrollService)
        {
            _startPage = startPage;
            _view = view;
            _levelFactory = levelFactory;
            _clickHandlerFactory = clickHandlerFactory;
            _scrollService = scrollService;
        }

        public void Enable()
        {
            _levelFactory.Create(_view.transform);
            _clickHandlerFactory.Create(_view.transform);
            _view.Button.AddListener(Scroll);
            _scrollService.ScrollEnded += OnScrollEnded;
        }

        public void Disable()
        {
            _view.Button.RemoveListener(Scroll);
            _scrollService.ScrollEnded -= OnScrollEnded;
        }

        private void Scroll()
        {
            if (_scrollService.ActivPage == _startPage.PageIndex)
                return;

            _scrollService.ScrollTo(_view.transform, _startPage.PageIndex);
        }

        private void OnScrollEnded()
        {
            if (_scrollService.ActivPage != _startPage.PageIndex)
            {
                _view.Button.Enable();
                return;
            }

            _view.Button.Disable();
        }
    }
}
