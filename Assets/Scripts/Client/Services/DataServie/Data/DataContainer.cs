using System;
using UnityEngine;
using Zenject;

namespace HDO.Client
{
    [Serializable]
    public class DataContainer : IInitializable
    {
        public static Action<string, DataContainer> OnRegistration;
        public static Action<string> OnSave;
        public string Key => GetType().ToString();

        [Inject]
        public void Initialize()
        {
            OnRegistration?.Invoke(Key, this);
        }

        public virtual string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
        public virtual void FromJson(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
            Save();
        }
        public void Save ()
        {
            OnSave?.Invoke(Key);
        }
    }
}