using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;

namespace Source.Codebase.Controllers.Presenters
{
    public class PageButtonPresenter : IPresenter
    {
        private readonly PageButton _pageButton;
        private readonly PageButtonView _view;
        private readonly PageConfig _config;

        public PageButtonPresenter(
            PageButton pageButton,
            PageButtonView view,
            PageConfig config)
        {
            _pageButton = pageButton;
            _view = view;
            _config = config;
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
        }
    }
}
