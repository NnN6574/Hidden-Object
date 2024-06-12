using System.Collections.Generic;
using HDO.Client.Library;
using UnityEngine;

namespace HDO.Client
{
    public class ImagesDataContainer : DataContainer
    {
        [SerializeField] private List<CachedImage> _data = new();
        public List<CachedImage> Data => _data;
    }
}