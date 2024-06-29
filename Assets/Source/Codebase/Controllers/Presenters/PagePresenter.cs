using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;

namespace Source.Codebase.Controllers.Presenters
{
    public class PagePresenter : IPresenter
    {
        private readonly Page _page;
        private readonly PageView _view;

        public PagePresenter(Page page, PageView view)
        {
            _page = page;
            _view = view;
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}
