using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace HDO.Client.Services
{
    public class NetworkService 
    {
        [Inject] private GameConfig _gameConfig;
        [Inject] private LevelsDataContainer _levelsDataContainer;


        public async Task<bool> Load()
        {
            var result = await LoadLevels();
            return result; 
        }

        public async Task<byte[]> LoadImageData(string url)
        {
            if (url == string.Empty)
            {
                return null;
            }
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var bytes = await response.Content.ReadAsByteArrayAsync();
             
                    return bytes;
                }
                catch (HttpRequestException ex)
                {
                    Debug.LogError(ex.Message);
                    return null;
                }
            }
        }

        public async Task<bool> LoadLevels()
        {
            var result = await GetRequest(_gameConfig.LevelsDataUrl);
            if (result == string.Empty)
            {
                return false;
            }
            _levelsDataContainer.FromJson(result);
            return true;
        }

        private async Task<string> GetRequest(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var result = await client.GetStringAsync(url);

                    return result;
                }
                catch (HttpRequestException ex)
                {
                   Debug.LogError(ex.Message);
                    return string.Empty;
                }
            }
        }
    }
}