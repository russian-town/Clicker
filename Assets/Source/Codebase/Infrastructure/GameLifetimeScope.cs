using Source.Codebase.Domain.Configs;
using Source.Codebase.Infrastructure;
using Source.Codebase.Infrastructure.Pool;
using Source.Codebase.Presentation;
using Source.Codebase.Presentation.Windows;
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
    [SerializeField] private WindowHolder _windowHolderTemplate;
    [SerializeField] private StartWindow _startWindowTemplate;
    [SerializeField] private UpgradeWindow _upgradeWindowTemplate;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterConfig(builder);
        var camera = RegisterCamera(builder);
        var canvas = RegisterCanvas(builder, camera);
        RegisterWindows(builder, canvas);
        builder.Register<SaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<Pool>(Lifetime.Transient).AsImplementedInterfaces().AsSelf();
        builder.Register<StaticDataService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<GameLoopService>(Lifetime.Singleton);
        builder.Register<ClickHandlerFactory>(Lifetime.Singleton);
        builder.Register<ClickEffectFactory>(Lifetime.Singleton);
        builder.Register<LevelFactory>(Lifetime.Singleton);
        builder.Register<SaveDataInjector>(Lifetime.Singleton);
        builder.Register<ItemFactory>(Lifetime.Singleton);
        builder.Register<ItemViewFactory>(Lifetime.Singleton);
        builder.RegisterEntryPoint<EntryPoint>();
    }

    private void RegisterConfig(IContainerBuilder builder)
    {
        builder.RegisterInstance(_gameConfig);
        builder.RegisterInstance(_clickEffectConfig);
    }

    private Camera RegisterCamera(IContainerBuilder builder)
    {
        var camera = Instantiate(_cameraTemplate);
        builder.RegisterComponent(camera);
        return camera;
    }

    private Canvas RegisterCanvas(IContainerBuilder builder, Camera camera)
    {
        var canvas = Instantiate(_canvasTemplate);
        builder.RegisterComponent(canvas);
        canvas.worldCamera = camera;
        return canvas;
    }

    private void RegisterWindows(IContainerBuilder builder, Canvas canvas)
    {
        var windowHolder = Instantiate(_windowHolderTemplate, canvas.transform);
        builder.RegisterComponent(windowHolder);
        var startWindow =
            Instantiate(_startWindowTemplate, windowHolder.Container);
        builder.RegisterComponent(startWindow);
        var upgradeWindow = 
            Instantiate(_upgradeWindowTemplate, windowHolder.Container);
        builder.RegisterComponent(upgradeWindow);
    }
}
