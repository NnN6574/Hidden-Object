using System.Collections.Generic;
using System.Threading.Tasks;
using HDO.Client.Library;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HDO.Client.UI
{
    public class LevelScreen : UiScreen
    {
        [Inject] private ScreenManager _screenManager;
        [Inject] private GameProcessDataContainer _gameProcessData;
        [Inject] private ImageLibrary _imageLibrary;
        [Inject] private LevelsDataContainer _levelsData;
        [Inject] private LevelsProgressDataContainer _levelsProgressData;

        [SerializeField] private Button _menuButton;
        [SerializeField] private Image _background;
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TMP_Text _progressText;

        [SerializeField] private List<LevelItem> _items;

        private LevelData _currentLevelData;
        public override async Task Load()
        {
            _currentLevelData = _levelsData.Data.Find(e => e.Id == _gameProcessData.Data.CurrentLevelId);
            var levelProgress = _levelsProgressData.Data.Find(e => e.Id == _currentLevelData.Id);
            var progress = 0;
            if (levelProgress != null)
            {
                progress = levelProgress.Progress;
            }
            var background = await _imageLibrary.GetImage(_currentLevelData.ImageName, _currentLevelData.ImageUrl);
            _background.sprite = background;

            CreateItems();

            UpdateProgress(progress);
            await base.Show();
        }
        public override Task Hide()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].OnClick -= SelectItem;
            }
            return base.Hide();
        }
        private void CreateItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].OnClick += SelectItem;
            }
        }
        private void SelectItem(int id)
        {
            _gameProcessData.Data.SelectedItemId = id;
        }

        private void Awake()
        {
            _menuButton.onClick.AddListener(BackToMenu);
            _gameProcessData.Data.OnChangedCurrentProgress += UpdateProgress;
        }

        private void UpdateProgress(int value)
        {          
            _progressText.text = $"{value}/{_currentLevelData.Counter}";
            _progressSlider.value = (float)value / _currentLevelData.Counter;
        }

        private void BackToMenu()
        {
            _screenManager.LoadScreen(ScreenId.Menu, true);
        }
    }
}