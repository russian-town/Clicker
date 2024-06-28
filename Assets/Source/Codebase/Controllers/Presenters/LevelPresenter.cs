using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services;

namespace Source.Codebase.Controllers.Presenters
{
    public class LevelPresenter : IPresenter
    {
        private readonly Level _level;
        private readonly LevelView _view;
        private readonly GameLoopService _gameLoopService;

        public LevelPresenter(
            Level level,
            LevelView view,
            GameLoopService gameLoopService)
        {
            _level = level;
            _view = view;
            _gameLoopService = gameLoopService;
        }

        public void Enable()
        {
            _level.DataReaded += OnDataReaded;
            _gameLoopService.Clicked += Onclicked;
            _level.ClickCountUpdated += OnClickCountUpdated;
            _level.LevelComplete += OnLevelCompleted;
            _gameLoopService.ClickForceUpdated += OnClickForceUpdated;
        }

        public void Disable()
        {
            _level.DataReaded -= OnDataReaded;
            _gameLoopService.Clicked -= Onclicked;
            _level.ClickCountUpdated -= OnClickCountUpdated;
            _level.LevelComplete -= OnLevelCompleted;
            _gameLoopService.ClickForceUpdated -= OnClickForceUpdated;
        }

        private void UpdateText(int levelNumber)
        {
            string levelText = $"Level {levelNumber}";
            string needClickText = $"Need: {_level.NeedClickPerNextLevel}";
            _view.SetLevelText(levelText);
            _view.SetNeedClickText(needClickText);
        }

        private void OnDataReaded(int levelNumber, int clickCount)
        {
            UpdateText(levelNumber);
            OnClickCountUpdated(clickCount);
        }

        private void Onclicked(int clickForce)
            => _level.UpdateClickCount(clickForce);

        private void OnLevelCompleted(int levelNumber)
            => UpdateText(levelNumber);

        private void OnClickCountUpdated(int clickCount)
        {
            float value = (float)clickCount / _level.NeedClickPerNextLevel;
            _view.SetValue(value);
        }

        private void OnClickForceUpdated(int clickForce)
        {
            string forcePerClickText = $"{clickForce} per click";
            _view.SetForcePerClickText(forcePerClickText);
        }
    }
}