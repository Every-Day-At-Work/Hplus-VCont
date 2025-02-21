using System.Collections.Generic;
using GameFoundation.MemoryPool;
using UnityEngine;

/// <summary>
/// Generic object pool that reuses objects instead of instantiating new ones.
/// </summary>
/// <typeparam name="T">The type of object being pooled.</typeparam>
public class ObjectPool<T> : IObjectPool<T> where T : Component, IPoolable
{
    private readonly Stack<T>  _pool = new();
    private readonly Transform _parent;
    private readonly T         _prefab;

    public ObjectPool(T prefab, Transform parent = null)
    {
        _prefab = prefab;
        _parent = parent;
    }

    /// <summary>
    /// Retrieves an object from the pool or creates a new one.
    /// </summary>
    public T Get()
    {
        T instance;

        if (_pool.Count > 0)
        {
            instance = _pool.Pop();
            instance.gameObject.SetActive(true);
        }
        else
        {
            instance = Object.Instantiate(_prefab, _parent);
        }

        instance.OnSpawned();
        return instance;
    }

    /// <summary>
    /// Returns an object to the pool for reuse.
    /// </summary>
    public void Release(T instance)
    {
        instance.OnDespawned();
        instance.gameObject.SetActive(false);
        _pool.Push(instance);
    }
}