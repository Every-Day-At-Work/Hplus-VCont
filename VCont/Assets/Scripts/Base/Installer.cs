namespace Base
{
    using VContainer;

    public abstract class Installer<TDerived> where TDerived : Installer<TDerived>
    {
        public static void Install(IContainerBuilder builder, IObjectResolver resolver)
        {
            // 1️⃣ Register TDerived in the container
            builder.Register<TDerived>(Lifetime.Singleton);
            resolver.Resolve<TDerived>().InstallBinding(builder, resolver);
            
        }

        protected abstract void InstallBinding(IContainerBuilder builder,IObjectResolver resolver);
    }
}