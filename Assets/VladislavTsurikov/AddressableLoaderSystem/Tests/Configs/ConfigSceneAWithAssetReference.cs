using UnityEngine;

namespace VladislavTsurikov.AddressableLoaderSystem.Tests
{
    [CreateAssetMenu(fileName = "ConfigSceneA_WithAssetReference", menuName = "Test/ConfigSceneA_Ref")]
    public class ConfigSceneAWithAssetReference : ScriptableObject
    {
        public AssetReferenceGameObject PrefabRef;
    }
}