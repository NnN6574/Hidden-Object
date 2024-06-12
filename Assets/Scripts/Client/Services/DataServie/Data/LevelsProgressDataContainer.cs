using System.Collections.Generic;
using UnityEngine;

namespace HDO.Client
{
    public class LevelsProgressDataContainer : DataContainer
    {
        [SerializeField] private List<LevelProgressData> _data = new();

        public List<LevelProgressData> Data => _data;

        public void UpdateProgress(int levelId, int progress)
        {
            var progressData = _data.Find(e => e.Id == levelId);
            progressData.UpdateProgress(progress);
            Save();
        }
        public void UpdateLimit(int levelId, int limit)
        {
            var progressData = _data.Find(e => e.Id == levelId);
            progressData.UpdateLimit(limit);
            Save();
        }
        public void Complite(int levelId)
        {
            var progressData = _data.Find(e => e.Id == levelId);
            progressData.Complite();
            Save();
        }

        public void Add(LevelProgressData levelProgress)
        {
            _data.Add(levelProgress);
            Save();
        }
    }
}