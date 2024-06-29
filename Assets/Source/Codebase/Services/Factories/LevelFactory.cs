using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class LevelFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly GameLoopService _gameLoopService;

        public LevelFactory(
            IStaticDataService staticDataService,
            ISaveLoadService saveLoadService,
            GameLoopService gameLoopService)
        {
            _staticDataService = staticDataService;
            _saveLoadService = saveLoadService;
            _gameLoopService = gameLoopService;
        }

        public void Create(Transform parent)
        {
            Level level = new();
            _saveLoadService.AddIDataReader(level);
            _saveLoadService.AddIDataWriter(level);
            LevelView template =
                _staticDataService.GetViewTemplate<LevelView>();
            LevelView view = Object.Instantiate(template, parent);
            LevelPresenter levelPresenter = new(level, view, _gameLoopService);
            view.Construct(levelPresenter);
        }
    }
}
