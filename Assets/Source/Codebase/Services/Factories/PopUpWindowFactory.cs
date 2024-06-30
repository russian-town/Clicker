using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Infrastructure.Pool.Abstract;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.UI;
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

        public void Create(
            PopUpWindowConfig config,
            Transform parent,
            PopUpWindowService popUpWindowService)
        {
            PopUpWindow popUpWindow = new(config);
            PopUpWindowView view = _pool.Get() as PopUpWindowView;

            if (view == null)
            {
                PopUpWindowView template =
                    _staticDataService.GetViewTemplate<PopUpWindowView>();
                view = Object.Instantiate(template, parent);
                view.transform.SetLocalPositionAndRotation(
                    Vector3.zero, Quaternion.identity);
                view.SetPool(_pool);
            }
            else
            {
                view.transform.SetLocalPositionAndRotation(
                    Vector3.zero, Quaternion.identity);
            }

            PopUpWindowPresenter presenter =
                new(popUpWindow, view, _pool, popUpWindowService);
            view.Construct(presenter);
        }
    }
}
