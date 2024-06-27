using Source.Codebase.Domain.Configs;
using Source.Codebase.Infrastructure;
using Source.Codebase.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Transform _levelInfo;
    [SerializeField] private Transform _canvas;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_gameConfig);
        builder.Register<StaticDataService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<GameLoopService>(Lifetime.Singleton);
        builder.Register<ClickHandlerFactory>(Lifetime.Singleton).WithParameter(_canvas);
        builder.Register<ClickEffectFactory>(Lifetime.Singleton).WithParameter(_canvas);
        builder.Register<LevelProgressBarFactory>(Lifetime.Singleton).WithParameter(_levelInfo);
        builder.Register<LevelFactory>(Lifetime.Singleton).WithParameter(_levelInfo);
        builder.RegisterEntryPoint<EntryPoint>();
    }
}
