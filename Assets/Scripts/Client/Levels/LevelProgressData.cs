using System;
using UnityEngine;

namespace HDO.Client
{
    [Serializable]
    public class LevelProgressData
    {
        [SerializeField] private bool _isDone;
        [SerializeField] private int _id;
        [SerializeField] private int _progress;
        [SerializeField] private int _limit;

        public bool IsDone => _isDone;
        public int Id => _id;
        public int Progress => _progress;
        public int Limit => _limit;

        public LevelProgressData(int id, int counter, int limit)
        {
            _id = id;
            _progress = counter;
            _limit = limit;
        }
        public void UpdateLimit(int limit)
        {
            _limit = limit;
        }
        public void UpdateProgress(int counter)
        {
            _progress = counter;
        }
        public void Complite()
        {
            _isDone = true;
        }
    }
}