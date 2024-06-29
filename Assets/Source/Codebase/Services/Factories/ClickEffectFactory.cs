using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Infrastructure.Pool.Abstract;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class ClickEffectFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPool _pool;
        private readonly ClickEffectConfig _config;

        public ClickEffectFactory(
            IStaticDataService staticDataService,
            IPool pool,
            ClickEffectConfig config)
        {
            _staticDataService = staticDataService;
            _pool = pool;
            _config = config;
        }

        public void Create(int clickForce, Vector2 position)
        {
            ClickEffect clickEffect =
                new(_config.LifeTime, _config.FadeDuration, clickForce);
            ClickEffectView view = _pool.Get() as ClickEffectView;

            if (view == null)
            {
                ClickEffectView template =
                    _staticDataService.GetViewTemplate<ClickEffectView>();
                view =
                    Object.Instantiate(template, position, Quaternion.identity);
                view.SetPool(_pool);
            }
            else
            {
                view.transform.SetPositionAndRotation(position, Quaternion.identity);
            }

            ClickEffectPresenter clickEffectPresenter = new(clickEffect, view);
            view.Construct(clickEffectPresenter);
        }
    }
}
