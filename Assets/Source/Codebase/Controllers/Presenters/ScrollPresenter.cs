using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;

namespace Source.Codebase.Controllers.Presenters
{
    public class ScrollPresenter : IPresenter
    {
        private readonly Scroll _scroll;
        private readonly ScrollView _view;

        public ScrollPresenter(Scroll scroll, ScrollView view)
        {
            _scroll = scroll;
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
