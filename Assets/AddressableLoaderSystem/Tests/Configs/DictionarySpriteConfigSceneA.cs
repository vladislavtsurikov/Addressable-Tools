using UnityEngine;
using AYellowpaper.SerializedCollections;
using UnityEngine.AddressableAssets;

namespace AddressableLoaderSystem.Tests
{
    [CreateAssetMenu(fileName = "DictionarySpriteConfigSceneA", menuName = "Test/DictionarySpriteConfigSceneA")]
    public class DictionarySpriteConfigSceneA : BaseConfig
    {
        [SerializeField]
        public SerializedDictionary<string, AssetReferenceSprite> Sprites = new ();
    }
}