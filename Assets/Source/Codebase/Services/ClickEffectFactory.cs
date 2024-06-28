using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Models;
using Source.Codebase.Infrastructure.Pool.Abstract;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class ClickEffectFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly Transform _parent;
        private readonly IPool _pool;

        public ClickEffectFactory(
            IStaticDataService staticDataService,
            Transform parent,
            IPool pool)
        {
            _staticDataService = staticDataService;
            _parent = parent;
            _pool = pool;
        }

        public void Create(int currentClickForce, Vector2 position)
        {
            ClickEffect clickEffect = new(1);
            ClickEffectView view = _pool.Get() as ClickEffectView;

            if (view == null)
            {
                ClickEffectView template =
                    _staticDataService.GetViewTemplate<ClickEffectView>();
                view =
                    Object.Instantiate(template, position, Quaternion.identity, _parent);
                view.SetPool(_pool);
            }
            else
            {
                view.transform.SetPositionAndRotation(position, Quaternion.identity);
            }

            ClickEffectPresenter clickEffectPresenter =
                new(clickEffect, view, currentClickForce);
            view.Construct(clickEffectPresenter);
        }
    }
}
