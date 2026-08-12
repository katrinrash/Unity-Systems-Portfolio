using System.Collections.Generic;
using UnityEngine.UIElements;

/// <summary>
/// Handles dynamic creation and management of the shop skin grid.
/// 
/// Responsible for generating skin cells dynamically from the skin database,
/// assigning skin data, determining current skin states, and handling user
/// interactions with the grid.
/// </summary>

public class ShopGridManager
{
    //References
    private readonly GameDataManager _gameDataManager;
    private readonly ShopActivitiesManager _shop;
    private readonly SkinDatabaseSO _database;

    //UI
    private readonly VisualElement _grid;
    private readonly VisualTreeAsset _cellTemplate;

    private List<SkinCell> _cells;

    #region Live Cycle

    public ShopGridManager(VisualElement grid, VisualTreeAsset template, ShopActivitiesManager shop)
    {
        _gameDataManager = GameDataManager.Instance;
        _cells = new();

        _grid = grid;
        _shop = shop;
        _database = _gameDataManager.SkinDatabase;
        _cellTemplate = template;
    }

    public void Initialize()
    {
        _grid.Clear();

        foreach (SkinDataSO skin in _database.Skins)
        {
            SkinCell cell = CreateCell();

            cell.BindData(skin, GetState(skin.Id));
            cell.InitializeButton(OnPressed);

            _cells.Add(cell);
            _grid.Add(cell.GetRoot());

        }

    }

    public void ClearSubscriptions()
    {
        foreach (SkinCell cell in _cells)
        {
            cell.RemoveButtonCallback(OnPressed);
        }
    }

    #endregion

    #region SkinCell Management

    private SkinCell CreateCell()
    {
        VisualElement element = _cellTemplate.CloneTree();
        return new SkinCell(element);
    }

    private SkinCell.State GetState(int id)
    {
        if (_gameDataManager.IsSkinSelected(id))
            return SkinCell.State.Selected;

        if (_gameDataManager.IsSkinUnlocked(id))
            return SkinCell.State.Unlocked;

        return SkinCell.State.Locked;
    }

    #endregion

    private void OnPressed(SkinDataSO skin, SkinCell.State state)
    {
        switch (state)
        {
            case SkinCell.State.Locked:
                _shop.BuySkin(skin);
                break;

            case SkinCell.State.Unlocked:
                {
                    _cells[_gameDataManager.PlayerData.SelectedSkinID].FitToState(SkinCell.State.Unlocked);
                    _shop.SelectSkin(skin);
                }
                break;

        }

    }

}
