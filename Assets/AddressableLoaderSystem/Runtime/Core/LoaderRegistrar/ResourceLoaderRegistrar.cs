using System.Collections.Generic;

namespace AddressableLoaderSystem.Runtime.LoaderRegistrar
{
    public abstract class ResourceLoaderRegistrar
    {
        public abstract IEnumerable<ResourceLoader> GetLoaders();

        public void RegisterLoaders(ResourceLoaderManager manager)
        {
            foreach (var loader in GetLoaders())
            {
                manager.Register(loader);
            }
        }
    }
}