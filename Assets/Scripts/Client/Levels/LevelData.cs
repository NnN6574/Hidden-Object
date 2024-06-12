using System;
using UnityEngine;

namespace HDO.Client
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private int _id;
        [SerializeField] private string _imageUrl;
        [SerializeField] private string _imageName;
        [SerializeField] private int _counter;

        public int Id => _id;
        public string ImageUrl => _imageUrl;
        public string ImageName => _imageName;
        public int Counter => _counter;
    }
}