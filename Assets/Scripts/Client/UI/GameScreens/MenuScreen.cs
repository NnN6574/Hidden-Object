using System.Collections.Generic;
using System.Threading.Tasks;
using HDO.Client.Library;
using UnityEngine;
using Zenject;

namespace HDO.Client.UI
{
    public class MenuScreen : UiScreen
    {
        [Inject] private GameProcessDataContainer _gameProcessData;
        [Inject] private ImageLibrary _imageLibrary;
        [Inject] private LevelsDataContainer _levelsData;
        [Inject] private LevelsProgressDataContainer _levelsProgressData;

        [SerializeField] private Transform _levelsContainer;
        [SerializeField] private LevelPreview _levelPreviewPrefab;

        [SerializeField] private List<LevelPreview> _levelsPreview;
        public override async Task Load()
        {
            for (int i = 0; i < _levelsData.Data.Count; i++)
            {
                var level = _levelsData.Data[i];
                var levelProgress = _levelsProgressData.Data.Find(e => e.Id == level.Id);
                if (levelProgress == null)
                {
                    levelProgress = new LevelProgressData(level.Id, 0, level.Counter);
                    _levelsProgressData.Add(levelProgress);
                }
                var preview = GetPreview();
                var icon = await _imageLibrary.GetImage(level.ImageName, level.ImageUrl);
                
                preview.Show(level.ImageName,levelProgress, icon);
            }
            await base.Show();
        }
        public override Task Hide()
        {
            for (int i = 0; i < _levelsPreview.Count; i++)
            {
                _levelsPreview[i].Hide();
            }
            return base.Hide();
        }
        private LevelPreview GetPreview()
        {
            var previewIndex = _levelsPreview.FindIndex(e => e.isActive == false);
            if (previewIndex < 0)
            {
                var preview = Instantiate(_levelPreviewPrefab, _levelsContainer);
                _levelsPreview.Add(preview);
                preview.OnClick += SelectLevel;
                return preview;
            }
            return _levelsPreview[previewIndex];
        }

        private async void SelectLevel(int levelId)
        {
            _gameProcessData.Data.SelectedLevelId = levelId;
        }
    }
}