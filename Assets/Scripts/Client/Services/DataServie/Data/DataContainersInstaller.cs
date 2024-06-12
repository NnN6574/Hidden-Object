using HDO.Client;
using Zenject;

public class DataContainersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LevelsDataContainer>().AsSingle().NonLazy();
        Container.Bind<LevelsProgressDataContainer>().AsSingle().NonLazy();
        Container.Bind<ImagesDataContainer>().AsSingle().NonLazy();
        Container.Bind<GameProcessDataContainer>().AsSingle().NonLazy();
    }
}