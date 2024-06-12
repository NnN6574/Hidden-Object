using System.Linq;
using HDO.Client.Common;
using Zenject;

namespace HDO.Client.Services
{
    public class DataContainerService : IInitializable
    {
        private SerializedDictionary<string, DataContainer> _containers = new SerializedDictionary<string, DataContainer>();
        [Inject]
        public void Initialize()
        {
            DataContainer.OnRegistration += Registration;
            DataContainer.OnSave += SaveContainer;
        }

        public void Save()
        {
            var keys = _containers.Keys;
            for (int i = 0; i < keys.Count; i++)
            {
                SaveContainer(keys.ElementAt(i));
            }
        }

        private void Registration(string key, DataContainer container)
        {
            _containers.Add(key, container);
            LoadContainer(key);
        }
        private void LoadContainer(string key)
        {
            DataProvider.TryLoad(key, out var value);
            _containers[key].FromJson(value);

        }
        private void SaveContainer(string key)
        {
            DataProvider.Save(key, _containers[key].ToJson());
        }
    }
}