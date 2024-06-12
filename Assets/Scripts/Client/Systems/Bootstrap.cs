using System.Threading.Tasks;
using HDO.Client.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace HDO.Client
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private NetworkService _networkService;

        [SerializeField] private GameObject _networkPlaceholder;
        private void Start()
        {
            Loading();
        }

        private async Task Loading()
        {
            var result = await _networkService.Load();

            if (result == false)
            {
                _networkPlaceholder.SetActive(true);
                return;
            }
            SceneManager.LoadScene(1);
        }
    }
}