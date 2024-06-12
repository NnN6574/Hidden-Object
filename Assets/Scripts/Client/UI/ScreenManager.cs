using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace HDO.Client.UI
{
    public enum ScreenId
    {
        Menu,
        Level,
        Loading
    }
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private List<ScreenContainer> _screenContainers;
        [SerializeField] private UiScreen _previousScreen;
        public async Task<UiScreen> LoadScreen(ScreenId screenId, bool withLoading = false)
        {
            if (withLoading)
            {
                await LoadScreen(ScreenId.Loading);
            }

            var screenIndex = _screenContainers.FindIndex(e => e.Id == screenId);
            if (screenIndex < 0)
            {
                return null;
            }
            var uiScreen = _screenContainers[screenIndex].Screen;

            if (withLoading)
            {
                await uiScreen.Load();
            }
            else
            {
                await uiScreen.Show();
            }

            if (_previousScreen != null)
            {
                await _previousScreen.Hide();
            }
            _previousScreen = uiScreen;

            return uiScreen;
        }

        private void Start()
        {
            FirstLoading();
        }

        private async Task FirstLoading()
        {
            await LoadScreen(ScreenId.Menu, true);
        }
    }
}