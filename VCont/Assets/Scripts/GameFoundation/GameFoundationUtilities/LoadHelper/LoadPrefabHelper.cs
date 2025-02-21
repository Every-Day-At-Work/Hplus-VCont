namespace GameFoundation.GameFoundationUtilities.LoadHelper
{
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using GameFoundation.GameAssets;
    using UnityEngine;

    public class LoadPrefabHelper : ILoadLocalHelper<GameObject>
    {
        private readonly IGameAssets                    gameAssets;
        private          Dictionary<string, GameObject> cachedPrefab = new();

        public LoadPrefabHelper(IGameAssets gameAssets) { this.gameAssets = gameAssets; }

        private async UniTask<GameObject> PreloadGameObject(string item)
        {
            var awaitable = await this.gameAssets.LoadAssetAsync<GameObject>(item).ToUniTask();
            this.cachedPrefab.Add(item, awaitable);

            return awaitable;
        }

        public bool IsPreloaded(string item) { return this.cachedPrefab.ContainsKey(item); }

        public async UniTask<GameObject> LoadLocal(string key)
        {
            if (this.cachedPrefab.TryGetValue(key, out var gameObject))
            {
                return gameObject;
            }

            return await this.PreloadGameObject(key);
        }
    }
}