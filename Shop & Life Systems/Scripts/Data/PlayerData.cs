using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Data container representing the player's current game progress.
/// 
/// Stores all persistent player-related information, including coins, unlocked skins,
/// and the currently selected skin. This data is managed and accessed through the
/// GameDataManager, which is responsible for loading and saving it between sessions.
/// 
/// Provides controlled methods for modifying player data and notifying subscribed
/// systems when skin selection changes.
/// </summary>

[Serializable]
public class PlayerData
{
    public Action OnSkinUpdated;

    [field: SerializeField] public int Coins { get; private set; } = 0;
    [field: SerializeField] public List<int> UnlockedSkins { get; private set; } = new();
    [field: SerializeField] public int SelectedSkinID { get; private set; } = 0;

    public PlayerData(int coins, List<int> unlockedSkins, int selectedSkinID)
    {
        Coins = coins;
        UnlockedSkins = unlockedSkins;
        SelectedSkinID = selectedSkinID;
    }

    public void UpdateCoins(int amount)
    {
        Coins += amount;
    }

    public void AddUnlockedSkin(int skinID)
    {
        if (!UnlockedSkins.Contains(skinID))
        {
            UnlockedSkins.Add(skinID);
        }
    }

    public void SetSelectedSkin(int skinID)
    {
        if (UnlockedSkins.Contains(skinID))
        {
            SelectedSkinID = skinID;
            OnSkinUpdated?.Invoke();
        }
    }
}
