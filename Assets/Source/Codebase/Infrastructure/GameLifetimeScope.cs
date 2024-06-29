using Source.Codebase;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Infrastructure;
using Source.Codebase.Infrastructure.Pool;
using Source.Codebase.Services;
using Source.Codebase.Services.Factories;
using Source.Codebase.Services.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GameConfig _gameConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterConfig(builder);
        RegisterCamera(builder);
        builder.Register<SaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<Pool>(Lifetime.Transient).AsImplementedInterfaces().AsSelf();
        builder.Register<StaticDataService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<GameLoopService>(Lifetime.Singleton);
        builder.Register<ProgressService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<ClickHandlerFactory>(Lifetime.Singleton);
        builder.Register<ClickEffectFactory>(Lifetime.Singleton);
        builder.Register<LevelFactory>(Lifetime.Singleton);
        builder.Register<SaveDataInjector>(Lifetime.Singleton);
        builder.Register<ItemFactory>(Lifetime.Singleton);
        builder.Register<ItemViewFactory>(Lifetime.Singleton);
        builder.Register<HUDFactory>(Lifetime.Singleton);
        builder.Register<PageService>(Lifetime.Singleton);
        builder.Register<PageFactory>(Lifetime.Singleton);
        builder.Register<PageButtonFactory>(Lifetime.Singleton);
        builder.Register<PopUpWindowFactory>(Lifetime.Singleton);
        builder.RegisterEntryPoint<EntryPoint>();
    }

    private void RegisterConfig(IContainerBuilder builder)
    {
        builder.RegisterInstance(_gameConfig);
        builder.RegisterInstance(_gameConfig.ClickEffectConfig);
        builder.RegisterInstance(_gameConfig.PageConfigs);
    }

    private void RegisterCamera(IContainerBuilder builder)
    {
        var camera = Instantiate(_gameConfig.CameraTemplate);
        builder.RegisterComponent(camera);
    }
}
