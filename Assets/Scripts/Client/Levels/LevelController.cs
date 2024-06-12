using System.Threading.Tasks;
using HDO.Client.UI;
using Zenject;

namespace HDO.Client
{
    public class LevelController : IInitializable
    {
        [Inject] private GameProcessDataContainer _gameProcessData;
        [Inject] private LevelsDataContainer _levelsData;
        [Inject] private LevelsProgressDataContainer _levelsProgressData;
        [Inject] private ScreenManager _screenManager;

        private LevelData _currentLevelData;
        private LevelProgressData _currentLevelProgressData;
        
        [Inject]
        public void Initialize()
        {
            _gameProcessData.Data.OnChangedSelectedLevelId += SelectLevel;
            _gameProcessData.Data.OnChangedSelectedItemId += SelectItem;

        }

        private void SelectItem(int itemId)
        {
            if (_currentLevelProgressData.Progress >= _currentLevelProgressData.Limit)
            {
                return;
            }
         
            _levelsProgressData.UpdateProgress(_currentLevelData.Id, _currentLevelProgressData.Progress + 1);
            _gameProcessData.Data.CurrentProgress = _currentLevelProgressData.Progress;
            if (_currentLevelProgressData.Progress >= _currentLevelProgressData.Limit)
            {
                CompliteLevel();
            }
        }
        private async Task CompliteLevel()
        {
            _levelsProgressData.Complite(_currentLevelData.Id);
            await Task.Delay(300);
            await _screenManager.LoadScreen(ScreenId.Menu, true);
        }
        private void SelectLevel(int levelId)
        {
            _gameProcessData.Data.CurrentLevelId = levelId;
            LoadLevel();
        }
        private async Task LoadLevel()
        {
            var levelId = _gameProcessData.Data.CurrentLevelId;
            _currentLevelData = _levelsData.Data.Find(e => e.Id == levelId);
            _currentLevelProgressData = _levelsProgressData.Data.Find(e => e.Id == levelId);

            if (_currentLevelProgressData == null)
            {
                _levelsProgressData.Data.Add(new LevelProgressData(levelId, 0, _currentLevelData.Counter));
            }
            else
            {
                _levelsProgressData.UpdateLimit(levelId, _currentLevelData.Counter);
            }

            if (_currentLevelProgressData.IsDone && _currentLevelProgressData.Progress >= _currentLevelProgressData.Limit)
            {
                _levelsProgressData.UpdateProgress(levelId, 0);
            }
            await _screenManager.LoadScreen(ScreenId.Level, true);

        }
    }
}