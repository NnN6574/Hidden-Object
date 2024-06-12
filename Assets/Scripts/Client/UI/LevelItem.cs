using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HDO.Client
{
    public class LevelItem : MonoBehaviour, IPointerClickHandler
    {
        public Action<int> OnClick;

        private int id;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(id);
        }
    }
}