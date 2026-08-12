using UnityEngine.UIElements;

/// <summary>
/// Handles player currency operations and synchronization with the UI.
/// 
/// Provides functionality for checking available currency, adding and spending
/// coins, and updating the displayed currency value.
/// </summary>

public class CurrencyManager
{
    private readonly GameDataManager _gameDataManager;
    private readonly Label _coinUi;

    public CurrencyManager(GameDataManager gameDataManager, Label uiLabel)
    {
        _gameDataManager = gameDataManager;
        _coinUi = uiLabel;
    }

    public bool EnoughCoins(int amount)
    {
        return _gameDataManager.PlayerData.Coins >= amount;
    }

    public void UseCoins(int amount)
    {
        _gameDataManager.PlayerData.UpdateCoins(-amount);
        UpdateVisual();
    }

    public void AddCoins(int amount)
    {
        _gameDataManager.PlayerData.UpdateCoins(amount);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        _coinUi.text = $"Coins: {_gameDataManager.PlayerData.Coins}";
    }

}
