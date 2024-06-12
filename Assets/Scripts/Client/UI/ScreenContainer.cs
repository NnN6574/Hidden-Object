using System;
using UnityEngine;

namespace HDO.Client.UI
{
    [Serializable]
    public class ScreenContainer
    {
        [SerializeField] private ScreenId _id;
        [SerializeField] private UiScreen _screen;

        public ScreenId Id => _id;
        public UiScreen Screen => _screen;
    }
}