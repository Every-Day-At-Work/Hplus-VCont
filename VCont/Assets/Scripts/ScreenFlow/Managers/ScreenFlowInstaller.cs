namespace GameFoundation.Scripts.UIModule.ScreenFlow.Managers
{
    using Base;
    using GameFoundation.Observer.MessagePipe;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Signals;
    using GameFoundation.Scripts.UIModule.Utilities.UIStuff;
    using global::ScreenFlow.Managers;
    using VContainer;
    using VContainer.Unity;

    public class ScreenFlowInstaller : Installer<ScreenFlowInstaller>
    {
        protected override void InstallBinding(IContainerBuilder builder, IObjectResolver resolver)
        {
            builder.Register<SceneDirector>(Lifetime.Singleton);
            builder.RegisterComponentOnNewGameObject<ScreenManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.DeclareSignal<StartLoadingNewSceneSignal>();
            builder.DeclareSignal<FinishLoadingNewSceneSignal>();
            builder.DeclareSignal<ScreenCloseSignal>();
            builder.DeclareSignal<ScreenShowSignal>();
            builder.DeclareSignal<ScreenHideSignal>();
            builder.DeclareSignal<ManualInitScreenSignal>();
            builder.DeclareSignal<ScreenSelfDestroyedSignal>();
            builder.DeclareSignal<PopupShowedSignal>();
            builder.DeclareSignal<PopupHiddenSignal>();
            builder.DeclareSignal<PopupBlurBgShowedSignal>();

            // builder.BindIFactory<AutoCooldownTimer>().AsTransient(); // Not sure if necessary
        }
    }
}