/// <summary>
/// Manages skin purchasing logic and updates player unlock progress.
/// 
/// Separates purchase-related operations from UI and data storage systems.
/// </summary>

public class PurchaseManager
{
    private readonly GameDataManager _gameDataManager;

    public PurchaseManager(GameDataManager gameDataManager)
    {
        _gameDataManager = gameDataManager;
    }

    public void BuySkin(SkinDataSO skin)
    {
        _gameDataManager.PlayerData.AddUnlockedSkin(skin.Id);
        skin.SkinCell.FitToState(SkinCell.State.Unlocked);
    }
}
