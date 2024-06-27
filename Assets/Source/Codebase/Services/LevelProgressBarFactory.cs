using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class LevelProgressBarFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly GameLoopService _gameLoopService;
        private readonly Transform _parent;

        public LevelProgressBarFactory(
            IStaticDataService staticDataService,
            GameLoopService gameLoopService,
            Transform parent)
        {
            _staticDataService = staticDataService;
            _gameLoopService = gameLoopService;
            _parent = parent;
        }

        public void Create(int needClickPerNextLevel)
        {
            LevelProgressBar levelProgressBar = new(needClickPerNextLevel);
            LevelProgressBarView template =
                _staticDataService.GetViewTemplate<LevelProgressBarView>();
            LevelProgressBarView view = Object.Instantiate(template, _parent);
            LevelProgressBarPresenter presenter =
                new(levelProgressBar, view, _gameLoopService);
            view.Construct(presenter);
        }
    }
}
