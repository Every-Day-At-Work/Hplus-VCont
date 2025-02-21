namespace Base
{
    using GameFoundation;
    using VContainer;
    using VContainer.Unity;

    public class GameProjectInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // GameFoundationInstaller.Install(builder, this.Container);
            builder.Register<DummyService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}