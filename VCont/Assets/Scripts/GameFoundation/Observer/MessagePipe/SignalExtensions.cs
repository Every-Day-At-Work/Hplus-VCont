namespace GameFoundation.Observer.MessagePipe
{
    using global::MessagePipe;
    using VContainer;

    public static class SignalExtensions
    {
        private static readonly MessagePipeOptions Options = new();

        public static void DeclareSignal<TSignal>(this IContainerBuilder container)
        {
            container.RegisterMessageBroker<TSignal>(Options);
        }
    }
}