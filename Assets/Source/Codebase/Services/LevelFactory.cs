using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Presentation.Windows;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class LevelFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly GameLoopService _gameLoopService;
        private readonly StartWindow _startWindow;

        public LevelFactory(
            IStaticDataService staticDataService,
            ISaveLoadService saveLoadService,
            GameLoopService gameLoopService,
            StartWindow startWindow)
        {
            _staticDataService = staticDataService;
            _saveLoadService = saveLoadService;
            _gameLoopService = gameLoopService;
            _startWindow = startWindow;
        }

        public void Create()
        {
            Level level = new();
            _saveLoadService.AddIDataReader(level);
            _saveLoadService.AddIDataWriter(level);
            LevelView template =
                _staticDataService.GetViewTemplate<LevelView>();
            LevelView view = Object.Instantiate(template, _startWindow.transform);
            LevelPresenter levelPresenter = new(level, view, _gameLoopService);
            view.Construct(levelPresenter);
        }
    }
}
