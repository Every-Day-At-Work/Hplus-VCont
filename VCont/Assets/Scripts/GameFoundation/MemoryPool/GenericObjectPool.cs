using System;
using System.Collections.Generic;

namespace GameFoundation.MemoryPool
{
    /// <summary>
    /// Generic object pool that supports both MonoBehaviour and non-MonoBehaviour classes.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public class GenericObjectPool<T> : IObjectPool<T>
    {
        private readonly Stack<T>  _pool = new();
        private readonly Func<T>   _createInstance;
        private readonly Action<T> _onGet;
        private readonly Action<T> _onRelease;

        /// <summary>
        /// Creates a pool with custom create, get, and release actions.
        /// </summary>
        public GenericObjectPool(Func<T> createInstance, Action<T> onGet = null, Action<T> onRelease = null)
        {
            this._createInstance = createInstance;
            this._onGet          = onGet ?? (_ => { });
            this._onRelease      = onRelease ?? (_ => { });
        }

        public T Get()
        {
            var instance = this._pool.Count > 0 ? this._pool.Pop() : this._createInstance();
            this._onGet(instance);

            return instance;
        }

        public void Release(T obj)
        {
            this._onRelease(obj);
            this._pool.Push(obj);
        }
    }
}