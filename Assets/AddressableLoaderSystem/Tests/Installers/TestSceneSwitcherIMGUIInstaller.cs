using Zenject;

namespace AddressableLoaderSystem.Tests
{
    public class TestSceneSwitcherIMGUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TestSceneSwitcherIMGUI>().FromComponentInHierarchy().AsSingle();
        }
    }
}