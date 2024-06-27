using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class ClickEffectFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly Transform _parent;

        public ClickEffectFactory(
            IStaticDataService staticDataService,
            Transform parent)
        {
            _staticDataService = staticDataService;
            _parent = parent;
        }

        public void Create(int currentClickForce, Vector2 position)
        {
            ClickEffect clickEffect = new(1);
            ClickEffectView template =
                _staticDataService.GetViewTemplate<ClickEffectView>();
            ClickEffectView view =
                Object.Instantiate(template, position, Quaternion.identity, _parent);
            ClickEffectPresenter clickEffectPresenter =
                new(clickEffect, view, currentClickForce);
            view.Construct(clickEffectPresenter);
        }
    }
}
