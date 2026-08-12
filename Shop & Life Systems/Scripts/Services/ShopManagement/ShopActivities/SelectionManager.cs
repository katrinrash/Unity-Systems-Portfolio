/// <summary>
/// Manages skin selection logic and updates the player's active character.
/// 
/// Separates selection operations from UI and data storage systems.
/// </summary>

public class SelectionManager
{
    private readonly GameDataManager _gameDataManager;

    public SelectionManager(GameDataManager gameDataManager)
    {
        _gameDataManager = gameDataManager;
    }

    public void SelectSkin(SkinDataSO skin)
    {
        _gameDataManager.PlayerData.SetSelectedSkin(skin.Id);
        skin.SkinCell.FitToState(SkinCell.State.Selected);
    }
}
