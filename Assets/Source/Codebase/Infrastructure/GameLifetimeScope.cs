using Source.Codebase.Domain.Configs;
using Source.Codebase.Infrastructure;
using Source.Codebase.Infrastructure.Pool;
using Source.Codebase.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Canvas _canvasTemplate;
    [SerializeField] private Camera _cameraTemplate;
    [SerializeField] private Transform _levelInfoTemplate;

    protected override void Configure(IContainerBuilder builder)
    {
        var camera = Instantiate(_cameraTemplate);
        builder.RegisterComponent(camera);
        var canvas = Instantiate(_canvasTemplate);
        builder.RegisterComponent(canvas);
        canvas.worldCamera = camera;
        var levelInfo = Instantiate(_levelInfoTemplate, canvas.transform);
        builder.RegisterInstance(_gameConfig);
        builder.Register<Pool>(Lifetime.Transient).AsImplementedInterfaces().AsSelf();
        builder.Register<StaticDataService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<GameLoopService>(Lifetime.Singleton);
        builder.Register<ClickHandlerFactory>(Lifetime.Singleton).WithParameter(canvas.transform);
        builder.Register<ClickEffectFactory>(Lifetime.Singleton).WithParameter(canvas.transform);
        builder.Register<LevelProgressBarFactory>(Lifetime.Singleton).WithParameter(levelInfo);
        builder.Register<LevelFactory>(Lifetime.Singleton).WithParameter(levelInfo);
        builder.RegisterEntryPoint<EntryPoint>();
    }
}
