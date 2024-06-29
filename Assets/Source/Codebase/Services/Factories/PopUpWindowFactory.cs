using Source.Codebase.Domain.Models;
using Source.Codebase.Infrastructure.Pool.Abstract;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class PopUpWindowFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPool _pool;

        public PopUpWindowFactory(
            IStaticDataService staticDataService,
            IPool pool)
        {
            _staticDataService = staticDataService;
            _pool = pool;
        }

        public void Create(Transform parent)
        {
            PopUpWindow popUpWindow = new();
            PopUpWindowView template =
                _staticDataService.GetViewTemplate<PopUpWindowView>();
            PopUpWindowView view = Object.Instantiate(template, parent);
            PopUpWindowPresenter presenter = new(popUpWindow, view, _pool);
            view.Construct(presenter);
        }
    }
}
