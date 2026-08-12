using UnityEngine;

/// <summary>
/// Central manager responsible for handling persistent player data throughout the game.
/// 
/// This manager exists as a single instance for the entire application lifetime and
/// persists between scene changes using DontDestroyOnLoad.
/// 
/// It manages player-related data, including skin progression, selected skin,
/// and other saved gameplay information. It is also responsible for initializing,
/// loading, and saving player data through the SaveManager system.
/// </summary> 

public class GameDataManager : InstanceBaseClass<GameDataManager>
{
    [field: SerializeField] public PlayerData PlayerData { get; private set; }
    [field: SerializeField] public SkinDatabaseSO SkinDatabase { get; private set; }

    private SaveManager _saveManager;

    protected override void OnInstanceBaseClassAwake()
    {
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    #region Save/Load Game Data

    private void LoadGameData()
    { 
        _saveManager ??= new SaveManager();

        if (_saveManager.ValidSave())
        { 
            PlayerData = _saveManager.LoadPlayerData();
        }
    }

    public void SaveGameData()
    {
        _saveManager ??= new SaveManager();

        _saveManager.SavePlayerData(new PlayerDataSave(PlayerData));
    }

    #endregion

    #region Skin Management

    public SkinDataSO GetCurrentSkinData()
    {
        return SkinDatabase.GetSkin(PlayerData.SelectedSkinID);
    }

    public bool IsSkinUnlocked(int skinId)
    {
        return PlayerData.UnlockedSkins.Contains(skinId);
    }

    public bool IsSkinSelected(int skinId)
    {
        return PlayerData.SelectedSkinID == skinId;
    }

    #endregion

}
