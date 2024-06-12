using UnityEngine;

namespace HDO.Client
{
    public class GameProcessDataContainer : DataContainer
    {
        [SerializeField] private GameProcessData _data = new();

        public GameProcessData Data => _data;
    }
}