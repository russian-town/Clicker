using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Infrastructure.Pool.Abstract;
using Source.Codebase.Presentation;
using Source.Codebase.Services.UI;

public class PopUpWindowPresenter : IPresenter
{
    private readonly PopUpWindow _popUpWindow;
    private readonly PopUpWindowView _view;
    private readonly PopUpWindowService _popUpWindowService;

    public PopUpWindowPresenter(
        PopUpWindow popUpWindow,
        PopUpWindowView view,
        IPool pool,
        PopUpWindowService popUpWindowService)
    {
        _popUpWindow = popUpWindow;
        _view = view;
        _view.SetPool(pool);
        _popUpWindowService = popUpWindowService;
    }

    public void Enable()
    {
        _view.CloseButton.onClick.AddListener(OnCloseButtonClicked);
        _view.SetDescription(_popUpWindow.Description);
        _popUpWindowService.PageClosed += OnPageClosed;
        _view.StartMoveAnimation();
    }

    public void Disable()
    {
        _view.CloseButton.onClick.RemoveListener(OnCloseButtonClicked);
        _popUpWindowService.PageClosed -= OnPageClosed;
    }

    private void OnCloseButtonClicked()
    {
        _view.Destroy();
    }

    private void OnPageClosed()
    {
        _view.Destroy();
    }
}
