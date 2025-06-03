using Zenject;

namespace AddressableLoaderSystem.Runtime
{
    public class AddressableLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var manager = new ResourceLoaderManager(Container);

            Container.Bind<ResourceLoaderManager>().FromInstance(manager).AsSingle();
        }
    }
}