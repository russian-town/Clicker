using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;

namespace Source.Codebase.Controllers.Presenters
{
    public class LevelPresenter : IPresenter
    {
        private readonly Level _level;
        private readonly LevelView _view;

        public LevelPresenter(Level level, LevelView view)
        {
            _level = level;
            _view = view;
        }

        public void Enable()
        {
            string levelText = $"Level {_level.LevelNumber}";
            _view.SetText(levelText);
        }

        public void Disable()
        {
        }
    }
}