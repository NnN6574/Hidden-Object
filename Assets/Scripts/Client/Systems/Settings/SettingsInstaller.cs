using UnityEngine;
using Zenject;

namespace HDO.Client
{
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
    public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        [SerializeField] private GameConfig _gameConfig;
        public override void InstallBindings()
        {
            Container.BindInstance(_gameConfig).AsSingle();
        }
    }
}