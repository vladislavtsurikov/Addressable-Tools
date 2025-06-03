using Neutral.ReflectionUtility.Runtime;

namespace AddressableLoaderSystem.Runtime.LoaderRegistrar
{
    public static class LoaderRegistrarUtility
    {
        internal static void RegisterLoaderInitializers(ResourceLoaderManager manager)
        {
            var resourceLoaderRegistrar = ReflectionFactory.CreateAllInstances<ResourceLoaderRegistrar>();

            foreach (var registrar in resourceLoaderRegistrar)
            {
                registrar.RegisterLoaders(manager);
            }
        }
    }
}