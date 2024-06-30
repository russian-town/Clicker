using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Factories;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters.Pages
{
    public class NewsPagePresenter : IPresenter
    {
        private readonly NewsPage _newsPage;
        private readonly NewsPageView _view;
        private readonly PopUpWindowFactory _popUpWindowFactory;
        private readonly PageScrollService _scrollService;
        private readonly PopUpWindowService _popUpWindowService;
        private readonly PopUpWindowConfig[] _popUpWindowConfigs;

        private CancellationTokenSource _cancellation;
        private bool _inProcess;

        public NewsPagePresenter(
            NewsPage newsPage,
            NewsPageView view,
            PopUpWindowFactory popUpWindowFactory,
            PageScrollService scrollService,
            PopUpWindowConfig[] popUpWindowConfigs)
        {
            _newsPage = newsPage;
            _view = view;
            _popUpWindowFactory = popUpWindowFactory;
            _scrollService = scrollService;
            _popUpWindowConfigs = popUpWindowConfigs;
            _popUpWindowService = new();
        }

        public void Enable()
        {
            _view.Button.AddListener(Scroll);
            _scrollService.Scrolled += OnScrolled;
            _scrollService.ScrollEnded += OnScrollEnded;
        }

        public void Disable()
        {
            _view.Button.RemoveListener(Scroll);
            _scrollService.ScrollEnded -= OnScrollEnded;
        }

        private void Scroll()
        {
            if (_scrollService.ActivPage == _newsPage.PageIndex)
                return;

            _scrollService.ScrollTo(_view.transform, _newsPage.PageIndex);
        }

        private void OnScrolled(Transform transform)
        {
            if(_inProcess == false)
                return;

            _inProcess = false;
            _cancellation.Cancel();
        }

        private async void OnScrollEnded()
        {
            _cancellation = new();

            if (_scrollService.ActivPage != _newsPage.PageIndex)
            {
                _view.Button.Enable();
                _popUpWindowService.CloseAllWindows();
                return;
            }

            _inProcess = true;
            _view.Button.Disable();
            await CreatePopUpWindows(_cancellation);
        }

        private async UniTask CreatePopUpWindows(
            CancellationTokenSource cancellation)
        {
            for (int i = 0; i < _popUpWindowConfigs.Length; i++)
            {
                if (_inProcess == false)
                    break;

                try
                {
                    _popUpWindowFactory.Create(
                        _popUpWindowConfigs[i],
                        _view.transform,
                        _popUpWindowService);
                    await UniTask.Delay(
                        TimeSpan.FromSeconds(1),
                        cancellationToken: cancellation.Token);
                }
                catch { }
            }

            _inProcess = false;
        }
    }
}
