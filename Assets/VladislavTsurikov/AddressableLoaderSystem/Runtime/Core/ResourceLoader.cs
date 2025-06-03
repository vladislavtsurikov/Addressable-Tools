using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace VladislavTsurikov.AddressableLoaderSystem.Runtime.Core
{
    public abstract class ResourceLoader
    {
        public abstract UniTask LoadResourceLoader(CancellationToken token);

        protected virtual UniTask UnloadResourceLoader(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }

        public async UniTask Unload(CancellationToken cancellationToken)
        {
            AddressableAssetTracker.UnloadIfUnused(this);

            await UnloadResourceLoader(cancellationToken);
        }

        protected async UniTask<T> LoadAndTrack<T>(string key, CancellationToken cancellationToken) where T : Object
        {
            var result = await AddressableAssetTracker.TrackAndLoad<T>(key, this, cancellationToken);

            await AssetReferenceReflectionLoader.LoadAssetReferencesRecursive(result, this, cancellationToken);

            return result;
        }
    }
}