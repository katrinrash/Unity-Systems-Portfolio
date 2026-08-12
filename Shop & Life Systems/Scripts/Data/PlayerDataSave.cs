using System;
using System.Collections.Generic;

/// <summary>
/// Serializable wrapper used for converting PlayerData into a format suitable
/// for saving and loading.
/// </summary>

[Serializable]
public class PlayerDataSave
{
    public int coins;
    public List<int> unlockedSkins;
    public int selectedSkinID;

    public PlayerDataSave(PlayerData data)
    {
        coins = data.Coins;
        unlockedSkins = data.UnlockedSkins;
        selectedSkinID = data.SelectedSkinID;
    }

    public PlayerData ToPlayerData()
    {
        return new PlayerData(coins, unlockedSkins, selectedSkinID);
    }
}
