using HDO.Client.UI;
using UnityEngine;
using Zenject;

namespace HDO.Client
{
    public class GameServicesInstaller : MonoInstaller
    {
        [SerializeField] private ScreenManager _screenManager;
        public override void InstallBindings()
        {
            Container.BindInstance(_screenManager).AsSingle();
            Container.Bind<LevelController>().AsSingle().NonLazy();
        }
    }
}