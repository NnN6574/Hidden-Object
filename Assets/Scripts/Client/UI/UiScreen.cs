
using System.Threading.Tasks;
using UnityEngine;

namespace HDO.Client.UI
{
    public class UiScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        public virtual async Task Load()
        {
          
        }

        public virtual async Task Show ()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
            
        public virtual async Task Hide()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}
