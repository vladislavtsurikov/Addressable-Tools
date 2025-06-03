using VladislavTsurikov.AddressableLoaderSystem.Runtime.ZenjectIntegration;

namespace VladislavTsurikov.AddressableLoaderSystem.Tests
{
    [SceneFilter("TestScene_B")]
    public class SceneBConfigLoader : BindableResourceLoader
    {
        public ConfigSceneB Config { get; private set; }
        public ConfigSceneBWithAssetReference ConfigWithReference { get; private set; }
        
        public SceneBConfigLoader(DiContainer container) : base(container)
        {
        }

        public override async UniTask LoadResourceLoader(CancellationToken token)
        {
            Config = await LoadAndBind<ConfigSceneB>(token, "ConfigSceneB");
            ConfigWithReference = await LoadAndBind<ConfigSceneBWithAssetReference>(token,"ConfigSceneB_WithAssetReference");
        }
    }
}