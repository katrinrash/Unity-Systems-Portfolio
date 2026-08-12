using System;
using UnityEngine.UIElements;

/// <summary>
/// Represents a single skin item in the shop grid.
/// 
/// Responsible for connecting skin data with its UI representation,
/// managing the current visual state (Locked, Unlocked, Selected),
/// and handling user interaction with the cell button.
/// 
/// Each cell receives its data dynamically and updates its appearance
/// based on the current skin state.
/// </summary>

public class SkinCell
{
    public enum State
    {
        Locked,
        Unlocked,
        Selected
    }

    //UI
    private readonly VisualElement _root;
    private readonly Image _icon;
    private readonly Button _button;
    private readonly VisualElement _labelBox;
    private readonly Label _costLabel;

    //Data
    private SkinDataSO _data;
    private State _state;

    private Action<SkinDataSO, State> _buttonCallback;

    #region Life Cycle

    public SkinCell(VisualElement element)
    {
        _root = element;

        _icon = _root.Q<Image>("icon");
        _button = _root.Q<Button>("actionButton");
        _costLabel = _root.Q<Label>("costLabel");
        _labelBox = _root.Q<VisualElement>("labelBox");
    }

    public void BindData(SkinDataSO data, State state)
    {
        _data = data;

        _icon.sprite = data.SkinSprite;
        _costLabel.text = data.Price.ToString();
        _data.SetCell(this);

        FitToState(state);
    }

    public void InitializeButton(Action<SkinDataSO, State> callback)
    {
        _buttonCallback = callback;
        _button.clicked += HandleClick;
    }

    public void RemoveButtonCallback(Action<SkinDataSO, State> callback)
    {
        _button.clicked -= HandleClick;
    }

    #endregion

    public void FitToState(State state)
    {
        _state = state;

        switch (_state)
        {
            case State.Locked:
                _button.text = "Buy";
                break;


            case State.Unlocked:
                _button.text = "Select";
                break;

        }

        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        _labelBox.style.display = _state == State.Locked ? DisplayStyle.Flex : DisplayStyle.None;
        _button.style.display = _state == State.Selected ? DisplayStyle.None : DisplayStyle.Flex;
    }

    private void HandleClick()
    {
        _buttonCallback?.Invoke(_data, _state);
    }

    public VisualElement GetRoot()
    {
        return _root;
    }

}
