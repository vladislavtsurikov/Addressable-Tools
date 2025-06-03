using Zenject;

namespace AddressableLoaderSystem.Tests
{
    public class SceneBInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneBInjectionValidator>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}