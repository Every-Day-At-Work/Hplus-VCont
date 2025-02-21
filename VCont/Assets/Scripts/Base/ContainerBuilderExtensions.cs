using GameFoundation.GameFoundationUtilities;
using VContainer;

namespace Base
{
    /// <summary>
    /// Extension methods for IContainerBuilder to register all types derived from a base type.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Registers all types derived from the specified base type <typeparamref name="T"/> into the container.
        /// </summary>
        /// <typeparam name="T">The base type to find all derived types.</typeparam>
        /// <param name="builder">The VContainer builder to register dependencies.</param>
        /// <param name="asImplementedInterfaces">
        /// If true, registers each type with all of its implemented interfaces.
        /// If false, registers each type with itself, ignore other interfaces which implemented.
        /// </param>
        public static void RegisterAllTypeDerivedFrom<T>(this IContainerBuilder builder, bool asImplementedInterfaces = false)
        {
            foreach (var type in ReflectionUtils.GetAllDerivedTypes<T>())
            {
                var registration = builder.Register(type, Lifetime.Singleton);

                if (asImplementedInterfaces)
                {
                    registration.AsImplementedInterfaces();
                }
            }
        }
    }
}