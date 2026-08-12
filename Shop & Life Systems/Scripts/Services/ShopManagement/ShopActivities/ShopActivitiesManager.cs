using UnityEngine.UIElements;

/// <summary>
/// Coordinates shop-related player actions such as purchasing and selecting skins.
/// 
/// Acts as an entry point for shop operations by combining specialized systems:
/// currency management, purchase handling, and skin selection.
/// </summary>

public class ShopActivitiesManager
{
    private readonly GameDataManager _gameDataManager;

    private readonly PurchaseManager _purchaseManager;
    private readonly SelectionManager _selectionManager;
    private readonly CurrencyManager _currencyManager;

    public ShopActivitiesManager(Label coinLabel)
    {
        _gameDataManager = GameDataManager.Instance;

        _purchaseManager = new PurchaseManager(_gameDataManager);
        _selectionManager = new SelectionManager(_gameDataManager);
        _currencyManager = new CurrencyManager(_gameDataManager, coinLabel);
    }

    public void BuySkin(SkinDataSO skin)
    {
        if(!_currencyManager.EnoughCoins(skin.Price))
            return;
        
        _currencyManager.UseCoins(skin.Price);
        _purchaseManager.BuySkin(skin);
    }

    public void SelectSkin(SkinDataSO skin)
    {
        _selectionManager.SelectSkin(skin);
    }

}
