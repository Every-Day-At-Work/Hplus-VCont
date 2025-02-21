namespace GameFoundation.Observer
{
    using Base;
    using GameFoundation.Observer.MessagePipe;
    using global::MessagePipe;
    using VContainer;

    public class ObserverInstaller : Installer<ObserverInstaller>
    {
        protected override void InstallBinding(IContainerBuilder builder, IObjectResolver resolver)
        {
            // RegisterMessagePipe returns options.
            var options = builder.RegisterMessagePipe( /* configure option */);

            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            // RegisterMessageBroker: Register for IPublisher<T>/ISubscriber<T>, includes async and buffered.
            builder.RegisterMessageBroker<int>(options);

            builder.Register<MessagePipeSignalBus>(Lifetime.Singleton).As<ISignalBus>();
        }
    }
}