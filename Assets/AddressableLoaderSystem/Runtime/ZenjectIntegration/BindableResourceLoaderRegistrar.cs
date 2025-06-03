using System.Collections.Generic;
using AddressableLoaderSystem.Runtime.LoaderRegistrar;
using Neutral.ReflectionUtility.Runtime;
using Zenject;

namespace AddressableLoaderSystem.Runtime.ZenjectIntegration
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