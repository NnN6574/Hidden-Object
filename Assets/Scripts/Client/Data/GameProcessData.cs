using System;
using UnityEngine;

[Serializable]
public class GameProcessData 
{
    public Action<int> OnChangedCurrentLevelId;
    public Action<int> OnChangedSelectedLevelId;
    public Action<int> OnChangedCurrentProgress;
    public Action<int> OnChangedSelectedItemId;

    [SerializeField] private int _currentLevelId;
    [SerializeField] private int _selectedLevelId;
    [SerializeField] private int _currentProgress;
    [SerializeField] private int _selectedItemId;

    public int CurrentLevelId
    {
        get { return _currentLevelId; }
        set { _currentLevelId = value; OnChangedCurrentLevelId?.Invoke(_currentLevelId); }
    }
    public int SelectedLevelId
    {
        get { return _selectedLevelId; }
        set { _selectedLevelId = value; OnChangedSelectedLevelId?.Invoke(_selectedLevelId); }
    }
    public int CurrentProgress
    {
        get { return _currentProgress; }
        set { _currentProgress = value; OnChangedCurrentProgress?.Invoke(_currentProgress); }
    }
    public int SelectedItemId
    {
        get { return _selectedItemId; }
        set { _selectedItemId = value; OnChangedSelectedItemId?.Invoke(_selectedItemId); }
    }
}
