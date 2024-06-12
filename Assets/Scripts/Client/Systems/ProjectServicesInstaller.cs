using HDO.Client.Library;
using HDO.Client.Services;
using Zenject;
namespace HDO.Client
{
    public class ProjectServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DataContainerService>().AsSingle().NonLazy();
            Container.Bind<ImageLibrary>().AsSingle().NonLazy();
            Container.Bind<NetworkService>().AsSingle().NonLazy();
        }
    }
}