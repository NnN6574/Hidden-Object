using System.Collections.Generic;
using UnityEngine;

namespace HDO.Client
{
    public class LevelsDataContainer : DataContainer
    {
        [SerializeField]
        private List<LevelData> _data = new();

        public List<LevelData> Data => _data;
    }
}
