namespace GameFoundation
{
    using Base;
    using BlueprintFlow.BlueprintControlFlow;
    using GameConfig;
    using GameFoundation.GameAssets;
    using GameFoundation.GameFoundationUtilities;
    using GameFoundation.GameFoundationUtilities.ApplicationServices;
    using GameFoundation.GameFoundationUtilities.Audio;
    using GameFoundation.GameFoundationUtilities.LoadHelper;
    using GameFoundation.HandleUserDataServices;
    using GameFoundation.Logger;
    using GameFoundation.Observer;
    using GameFoundation.Observer.MessagePipe;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using GameFoundation.Scripts.Utilities.ObjectPool;
    using UnityEngine;
    using UserData;
    using VContainer;
    using VContainer.Unity;

    public class GameFoundationInstaller : Installer<GameFoundationInstaller>
    {
        protected override void InstallBinding(IContainerBuilder builder, IObjectResolver resolver)
        {
            ObserverInstaller.Install(builder, resolver);

            // Register game config. Other modules can call it config from the base game config.
            var gameConfig = Resources.Load<GDKConfig>("GameConfigs/GDKConfig"); //TODO: Create auto config tool
            builder.RegisterInstance(gameConfig);

            builder.Register<IGameAssets, GameAssets.GameAssets>(Lifetime.Singleton);

            // Register object pool
            builder.Register<ObjectPoolManager>(Lifetime.Singleton);

            //Audio service
            builder.Register<IAudioService, AudioService>(Lifetime.Singleton);

            //Service
            builder.Register<ILogService, LogService>(Lifetime.Singleton);

            //Game Manager
            builder.Register<IHandleUserDataServices, HandleLocalUserDataServices>(Lifetime.Singleton);

            builder.DeclareSignal<UserDataLoadedSignal>();

            //Generate fps
            builder.RegisterComponentOnNewGameObject<Fps>(Lifetime.Scoped, "FPS Counter");

            //Helper
            // builder.Register<LoadImageHelper>(Lifetime.Singleton);
            builder.RegisterAllTypeDerivedFrom<ILoadHelper>(true);

            //Installer
            BlueprintServicesInstaller.Install(builder, resolver);
            ScreenFlowInstaller.Install(builder, resolver);
            ApplicationServiceInstaller.Install(builder, resolver);
            // GameQueueActionInstaller.Install(builder, resolver);
        }
    }
}