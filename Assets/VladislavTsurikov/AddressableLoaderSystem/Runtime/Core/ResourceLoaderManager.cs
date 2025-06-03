using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace VladislavTsurikov.AddressableLoaderSystem.Runtime.Core
{
    public class ResourceLoaderManager
    {
        private readonly DiContainer _container;
        private readonly List<ResourceLoader> _allLoaders = new();
        private readonly HashSet<ResourceLoader> _activeLoaders = new();

        public IReadOnlyList<ResourceLoader> GetAllLoaders() => _allLoaders;

        public ResourceLoaderManager(DiContainer container)
        {
            _container = container;
            LoaderRegistrarUtility.RegisterLoaderInitializers(this);
        }

        public async UniTask Load(Func<FilterAttribute, bool> attributePredicate, CancellationToken cancellationToken = default)
        {
            var selected = new HashSet<ResourceLoader>();

            foreach (var loader in _allLoaders)
            {
                var attributes = loader.GetType()
                    .GetCustomAttributes(typeof(FilterAttribute), true)
                    .Cast<FilterAttribute>()
                    .ToArray();

                if (attributes.Any(attributePredicate))
                {
                    selected.Add(loader);
                }
            }

            Debug.Log($"[ResourceLoaderManager] Start Loading" +
                      $" \nSelected loaders to load: {string.Join(", ", selected.Select(l => l.GetType().Name))}");

            await UnloadObsoleteLoaders(selected, cancellationToken);
            await LoadMissingLoaders(selected, cancellationToken);

            _activeLoaders.Clear();

            foreach (var loader in selected)
            {
                _activeLoaders.Add(loader);
            }

            Debug.Log($"[ResourceLoaderManager] End Loading");
        }
        
        internal bool Register(ResourceLoader loader)
        {
            var type = loader.GetType();

            if (_allLoaders.Any(l => l.GetType() == type))
            {
                return false;
            }

            _allLoaders.Add(loader);
            _container.Bind(type).FromInstance(loader).AsSingle();

            return true;
        }

        private async UniTask UnloadObsoleteLoaders(HashSet<ResourceLoader> desired, CancellationToken cancellationToken)
        {
            var toUnload = _activeLoaders.Except(desired);
            foreach (var loader in toUnload)
            {
                await loader.Unload(cancellationToken);
            }
        }

        private async UniTask LoadMissingLoaders(HashSet<ResourceLoader> desired, CancellationToken cancellationToken)
        {
            var toLoad = desired.Except(_activeLoaders);
            foreach (var loader in toLoad)
            {
                await loader.LoadResourceLoader(cancellationToken);
            }
        }
    }
}