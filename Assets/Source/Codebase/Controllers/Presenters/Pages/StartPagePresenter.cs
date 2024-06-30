using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Factories;

namespace Source.Codebase.Controllers.Presenters.Pages
{
    public class StartPagePresenter : IPresenter
    {
        private readonly StartPage _startPage;
        private readonly StartPageView _view;
        private readonly LevelFactory _levelFactory;
        private readonly ClickHandlerFactory _clickHandlerFactory;

        public StartPagePresenter(
            StartPage startPage,
            StartPageView view,
            LevelFactory levelFactory,
            ClickHandlerFactory clickHandlerFactory)
        {
            _startPage = startPage;
            _view = view;
            _levelFactory = levelFactory;
            _clickHandlerFactory = clickHandlerFactory;
        }

        public void Enable()
        {
            _levelFactory.Create(_view.transform);
            _clickHandlerFactory.Create(_view.transform);
        }

        public void Disable() { }
    }
}
