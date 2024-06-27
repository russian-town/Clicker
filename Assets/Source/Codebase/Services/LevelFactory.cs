using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class LevelFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly Transform _parent;

        public LevelFactory(
            IStaticDataService staticDataService,
            Transform parent)
        {
            _staticDataService = staticDataService;
            _parent = parent;
        }

        public void Create()
        {
            Level level = new();
            LevelView template =
                _staticDataService.GetViewTemplate<LevelView>();
            LevelView view = Object.Instantiate(template, _parent);
            LevelPresenter levelPresenter = new(level, view);
            view.Construct(levelPresenter);
        }
    }
}
