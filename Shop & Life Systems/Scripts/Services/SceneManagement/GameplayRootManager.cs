using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Controls the visibility and availability of the main gameplay root when
/// additional scenes are loaded additively.
/// 
/// Responsible for enabling and disabling the main gameplay UI and objects
/// during transitions to independent scene modules, such as the Shop.
/// </summary>

public class GameplayRootManager : MonoBehaviour
{
    [SerializeField] private HandlerUI rootHolder;
    [SerializeField] private GameObject rootSceneObject;

    private VisualElement _rootVisualElement;

    private void Start()
    {
        SceneManagerService.Instance.SetRootSceneObject(this);
        _rootVisualElement = rootHolder.GetRootElement();
    }

    public void EnableRoot()
    { 
        rootSceneObject.SetActive(true);
        _rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void DisableRoot()
    {
        rootSceneObject.SetActive(false);
        _rootVisualElement.style.display = DisplayStyle.None;
    }
}
