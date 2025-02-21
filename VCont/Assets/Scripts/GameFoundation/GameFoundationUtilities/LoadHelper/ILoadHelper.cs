namespace GameFoundation.GameFoundationUtilities.LoadHelper
{
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public interface ILoadHelper
    {
        
    }
    public interface ILoadLocalHelper<T> : ILoadHelper
    {
        public UniTask<T> LoadLocal(string key);
    }

    public interface ILoadFromUrlHelper<T> : ILoadHelper
    {
        public UniTask<T> LoadFromUrl(string url);
    }
}