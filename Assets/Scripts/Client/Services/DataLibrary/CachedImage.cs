using System;
using UnityEngine;

namespace HDO.Client.Library
{
    [Serializable]
    public class CachedImage
    {
        [SerializeField] private string _name;
        [SerializeField] private byte[] _cach;

        public string Name => _name;
        public byte[] Chash => _cach;

        public CachedImage(string name, byte[] cach)
        {
            _name = name;
            _cach = cach;
        }
    }
}