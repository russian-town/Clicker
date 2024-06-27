using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services;
using System;
using UnityEngine;

namespace Source.Codebase.Controllers.Presenters
{
    public class LevelProgressBarPresenter : IPresenter
    {
        private readonly LevelProgressBar _levelProgressBar;
        private readonly LevelProgressBarView _view;
        private readonly GameLoopService _gameLoopService;

        public LevelProgressBarPresenter(
            LevelProgressBar levelProgressBar,
            LevelProgressBarView view,
            GameLoopService gameLoopService)
        {
            _levelProgressBar = levelProgressBar;
            _view = view;
            _gameLoopService = gameLoopService;
        }

        public void Enable()
        {
            _levelProgressBar.ClickCountUpdated += OnClickCountUpdated;
            _gameLoopService.Clicked += OnClicked;
            //_levelProgressBar.UpdateClickCount(playerData);
        }

        public void Disable()
        {
            _levelProgressBar.ClickCountUpdated -= OnClickCountUpdated;
            _gameLoopService.Clicked -= OnClicked;
        }

        private void OnClicked(int clickForce)
            => _levelProgressBar.UpdateClickCount(clickForce);

        private void OnClickCountUpdated(int clickCount)
        {
            float value = (float)clickCount / _levelProgressBar.NeedClickPerNextLevel;
            _view.UpdateSlider(value);
        }
    }
}
