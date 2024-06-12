using UnityEngine;

namespace HDO.Client
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "System/GameConfig")]

    public class GameConfig : ScriptableObject
    {
        [SerializeField] private string _levelsDataUrl;
        public string LevelsDataUrl => _levelsDataUrl;
    }
}