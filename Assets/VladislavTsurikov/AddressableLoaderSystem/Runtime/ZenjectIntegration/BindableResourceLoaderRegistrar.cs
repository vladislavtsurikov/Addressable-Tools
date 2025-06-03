using VladislavTsurikov.AddressableLoaderSystem.Runtime.Core;

namespace VladislavTsurikov.AddressableLoaderSystem.Runtime.ZenjectIntegration
{
    public class BindableResourceLoaderRegistrar : ResourceLoaderRegistrar
    {
        public override IEnumerable<ResourceLoader> GetLoaders()
        {
            var container = ProjectContext.Instance.Container;
            return ReflectionFactory.CreateAllInstances<BindableResourceLoader>(container);
        }
    }
}