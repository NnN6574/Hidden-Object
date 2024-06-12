using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HDO.Client.UI
{
    public class LevelPreview : MonoBehaviour,IPointerClickHandler
    {
        public Action<int> OnClick;

        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _progressText;
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private GameObject _compliteMarker;
        [SerializeField] private GameObject _locker;

        private bool _isActive;
        private bool _isValid;
        private int _levelId;
        public bool isActive => _isActive;

        public void Show(string title, LevelProgressData levelProgress, Sprite icon)
        {
            _levelId = levelProgress.Id;
            _isValid = icon != null;
            _locker.SetActive(!_isValid);
            _icon.sprite = icon;
            _titleText.text = $"{title}";
            _progressText.text = $"{levelProgress.Progress} / {levelProgress.Limit}";
            _compliteMarker.SetActive(levelProgress.IsDone);
            _isActive = true;
            gameObject.SetActive(_isActive);
        }

        public void Hide()
        {
            _isActive = false;
            gameObject.SetActive(_isActive);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isValid == false) return;

            OnClick?.Invoke(_levelId);
        }
    }
}