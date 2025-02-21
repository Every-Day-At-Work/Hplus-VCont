namespace GameFoundation.GameFoundationUtilities.ApplicationServices
{
    using Base;
    using GameFoundation.Observer.MessagePipe;
    using GameFoundation.Scripts.Utilities.ApplicationServices;
    using VContainer;
    using VContainer.Unity;

    public class ApplicationServiceInstaller : Installer<ApplicationServiceInstaller>
    {
        protected override void InstallBinding(IContainerBuilder builder, IObjectResolver resolver)
        {
            builder.RegisterComponentOnNewGameObject<MinimizeAppService>(Lifetime.Singleton);
            builder.DeclareSignal<ApplicationPauseSignal>();
            builder.DeclareSignal<ApplicationQuitSignal>();
            builder.DeclareSignal<UpdateTimeAfterFocusSignal>();
        }
    }
}