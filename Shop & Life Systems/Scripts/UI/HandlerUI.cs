using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Base UI handler responsible for providing access to the root VisualElement
/// of a UI Toolkit document.
/// 
/// Acts as a shared helper component for UI systems that need to interact
/// with the interface hierarchy while keeping root element access centralized.
/// </summary>

public class HandlerUI : MonoBehaviour
{
    protected VisualElement _root;

    public VisualElement GetRootElement()
    {
        return _root;
    }
}
