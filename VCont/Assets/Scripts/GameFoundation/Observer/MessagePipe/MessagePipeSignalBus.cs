namespace GameFoundation.Observer.MessagePipe
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using global::MessagePipe;
    using VContainer;
    using Debug = UnityEngine.Debug;

    public class MessagePipeSignalBus : ISignalBus, IDisposable
    {
        private readonly IObjectResolver                                               resolver;
        private readonly Dictionary<(Type SignalType, Delegate Callback), IDisposable> subscriptions = new();

        public MessagePipeSignalBus(IObjectResolver resolver) { this.resolver = resolver; }

        public virtual void Fire<TSignal>() { this.GetPublisher<TSignal>().Publish(default); }

        public virtual void Fire<TSignal>(TSignal signal) { this.GetPublisher<TSignal>().Publish(signal); }

        public virtual void Subscribe<TSignal>(Action callback)
        {
            if (!this.TrySubscribeInternal<TSignal>(callback))
            {
                Debug.LogError($"Callback {typeof(TSignal)} already subscribed");
            }
        }

        public virtual void Subscribe<TSignal>(Action<TSignal> callback)
        {
            if (!this.TrySubscribeInternal<TSignal>(callback))
            {
                Debug.LogError($"Callback {typeof(TSignal)} already subscribed");
            }
        }

        public virtual bool TrySubscribe<TSignal>(Action callback) { return this.TrySubscribeInternal<TSignal>(callback); }

        public virtual bool TrySubscribe<TSignal>(Action<TSignal> callback) { return this.TrySubscribeInternal<TSignal>(callback); }

        public virtual void Unsubscribe<TSignal>(Action callback)
        {
            if (!this.TryUnsubscribeInternal<TSignal>(callback))
            {
                var stackTrace   = new StackTrace();
                var frame        = stackTrace.GetFrame(1);
                var method       = frame.GetMethod();
                var callerMethod = method.Name;
                if (callerMethod.Contains("OnDestroy"))
                {
                    return;
                }

                Debug.LogError($"Callback {typeof(TSignal)} not subscribed");
            }
        }

        public virtual void Unsubscribe<TSignal>(Action<TSignal> callback)
        {
            if (!this.TryUnsubscribeInternal<TSignal>(callback))
            {
                Debug.LogError($"Callback {typeof(TSignal)} not subscribed");
            }
        }

        public virtual bool TryUnsubscribe<TSignal>(Action callback) { return this.TryUnsubscribeInternal<TSignal>(callback); }

        public virtual bool TryUnsubscribe<TSignal>(Action<TSignal> callback) { return this.TryUnsubscribeInternal<TSignal>(callback); }

        private IPublisher<TSignal> GetPublisher<TSignal>()
        {
            if (!this.resolver.TryResolve<IPublisher<TSignal>>(out var resolved))
                throw new($"Signal {typeof(TSignal)} not declared");

            return resolved;
        }

        private ISubscriber<TSignal> GetSubscriber<TSignal>()
        {
            if (!this.resolver.TryResolve<ISubscriber<TSignal>>(out var resolved))
                throw new($"Signal {typeof(TSignal)} not declared");

            return resolved;
        }
        
        private bool TrySubscribeInternal<TSignal>(Delegate callback)
        {
            if (callback is null) throw new ArgumentNullException(nameof(callback));
            var key = (typeof(TSignal), callback);

            if (this.subscriptions.ContainsKey(key)) return false;

            var wrapper = callback switch
            {
                Action action => _ => action(),
                Action<TSignal> action => action,
                _ => throw new ArgumentException("Callback type not supported"),
            };

            var subscription = this.GetSubscriber<TSignal>().Subscribe(wrapper);
            this.subscriptions.Add(key, subscription);

            return true;
        }

        private bool TryUnsubscribeInternal<TSignal>(Delegate callback)
        {
            if (callback is null) throw new ArgumentNullException(nameof(callback));
            var key = (typeof(TSignal), callback);

            if (!this.subscriptions.Remove(key, out var subscription)) return false;
            subscription.Dispose();

            return true;
        }

        public void Dispose()
        {
            foreach (var subscription in this.subscriptions.Values)
            {
                subscription.Dispose();
            }

            this.subscriptions.Clear();
        }
    }
}