using System.Threading.Tasks;
using HDO.Client.Services;
using UnityEngine;
using Zenject;

namespace HDO.Client.Library
{
    public class ImageLibrary
    {
        [Inject] private ImagesDataContainer _imagesData;
        [Inject] private NetworkService _networkService;

    
        public async Task<Sprite> GetImage(string name, string url)
        {
            byte[] bytes;
            var texture = new Texture2D(0, 0);

            var index = _imagesData.Data.FindIndex(e => e.Name == name);
            if (index < 0)
            {
                bytes = await _networkService.LoadImageData(url);
                if (bytes == null)
                {
                    return null;
                }
                AddImage(name, bytes);
            }
            else
            {
                bytes = _imagesData.Data[index].Chash;
            }
            texture.LoadImage(bytes);
            var result = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            return result;
        }
        private void AddImage(string name, byte[] cach)
        {
            _imagesData.Data.Add(new CachedImage(name, cach));
            _imagesData.Save();
        }
    }
}