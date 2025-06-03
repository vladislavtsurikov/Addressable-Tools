using UnityEngine;

namespace VladislavTsurikov.AddressableLoaderSystem.Tests
{
    public class PrefabSpawner : MonoBehaviour
    {
        [Inject] private ConfigSceneAWithAssetReference _config;
    
        private async void Start()
        {
            await SpawnPrefab();
        }

        private async UniTask SpawnPrefab()
        {
            await _config.PrefabRef.InstantiateWithAutoLoad();
        }
    }
}