namespace GameFoundation.MemoryPool
{
    /// <summary>
    /// Interface for a generic object pool.
    /// </summary>
    /// <typeparam name="T">The type of object being pooled.</typeparam>
    public interface IObjectPool<T>
    {
        /// <summary>
        /// Retrieves an object from the pool or creates a new one.
        /// </summary>
        /// <returns>An instance of T.</returns>
        T Get();

        /// <summary>
        /// Returns an object to the pool for reuse.
        /// </summary>
        /// <param name="item">The object to return.</param>
        void Release(T item);
    }
    
    /// <summary>
    /// Interface for objects that can be reused in an object pool.
    /// </summary>
    public interface IPoolable
    {
        /// <summary>
        /// Called when the object is retrieved from the pool.
        /// </summary>
        void OnSpawned();

        /// <summary>
        /// Called when the object is returned to the pool.
        /// </summary>
        void OnDespawned();
    }
}