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
    [SerializeField] private ClickEffectConfig _clickEffectConfig;
    [SerializeField] private Canvas _canvasTemplate;
    [SerializeField] private Camera _cameraTemplate;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_gameConfig);
        builder.RegisterInstance(_clickEffectConfig);
        var camera = Instantiate(_cameraTemplate);
        builder.RegisterComponent(camera);
        var canvas = Instantiate(_canvasTemplate);
        builder.RegisterComponent(canvas);
        canvas.worldCamera = camera;
        builder.Register<SaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<Pool>(Lifetime.Transient).AsImplementedInterfaces().AsSelf();
        builder.Register<StaticDataService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<GameLoopService>(Lifetime.Singleton);
        builder.Register<ClickHandlerFactory>(Lifetime.Singleton).WithParameter(canvas.transform);
        builder.Register<ClickEffectFactory>(Lifetime.Singleton).WithParameter(canvas.transform);
        builder.Register<LevelFactory>(Lifetime.Singleton).WithParameter(canvas.transform);
        builder.RegisterEntryPoint<EntryPoint>();
    }
}
