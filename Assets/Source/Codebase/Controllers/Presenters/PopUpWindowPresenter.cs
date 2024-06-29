using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Infrastructure.Pool.Abstract;
using Source.Codebase.Presentation;

public class PopUpWindowPresenter : IPresenter
{
    private readonly PopUpWindow _popUpWindow;
    private readonly PopUpWindowView _view;

    public PopUpWindowPresenter(
        PopUpWindow popUpWindow,
        PopUpWindowView view,
        IPool pool)
    {
        _popUpWindow = popUpWindow;
        _view = view;
        _view.SetPool(pool);
    }

    public void Enable()
    {
        _view.CloseButton.onClick.AddListener(OnCloseButtonClicked);
    }

    public void Disable()
    {
        _view.CloseButton.onClick.RemoveListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        _view.Destroy();
    }
}
