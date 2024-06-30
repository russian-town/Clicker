using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation.Pages;
using Source.Codebase.Services.Factories;

namespace Source.Codebase.Controllers.Presenters.Pages
{
    public class NewsPagePresenter : IPresenter
    {
        private readonly NewsPage _newsPage;
        private readonly NewsPageView _view;
        private readonly PopUpWindowFactory _popUpWindowFactory;
        private readonly int _popUpWindowCount = 4;

        public NewsPagePresenter(
            NewsPage newsPage,
            NewsPageView view,
            PopUpWindowFactory popUpWindowFactory)
        {
            _newsPage = newsPage;
            _view = view;
            _popUpWindowFactory = popUpWindowFactory;
        }

        public void Enable()
        {
            for (int i = 0; i < _popUpWindowCount; i++)
            {
                _popUpWindowFactory.Create(_view.transform);
            }
        }

        public void Disable()
        {
        }
    }
}
