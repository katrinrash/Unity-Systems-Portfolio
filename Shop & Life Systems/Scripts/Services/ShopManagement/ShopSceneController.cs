using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Main controller of the Shop scene.
/// 
/// Serves as the entry point for the shop module initialization. 
/// Responsible for setting up the Shop UI, initializing required managers,
/// and connecting different shop systems together.
/// 
/// Handles the overall scene-level flow while keeping specific shop logic
/// separated into dedicated managers.
/// </summary>

[RequireComponent(typeof(UIDocument))]
public class ShopSceneController : MonoBehaviour 
{
    [SerializeField] private VisualTreeAsset skinCellTemplate;

    //UI
    private UIDocument _document;
    private VisualElement _root;
    private VisualElement _grid;
    private Label _coinsLabel;
    private Button _closeButton;

    //Management
    private ShopGridManager _gridManager;
    private ShopActivitiesManager _shopManager;
    private readonly SceneManagerService _sceneManagerService = SceneManagerService.Instance;

    #region Unity Lifecycle

    private void Start()
    {
        _document = GetComponent<UIDocument>();

        _root = _document.rootVisualElement;
        _grid = _root.Q<VisualElement>("skinGrid");
        _coinsLabel = _root.Q<Label>("coinsLabel");
        _closeButton = _root.Q<Button>("closeButton");

        SetupManagers();
        SetupCoins();
        SetupSceneManagement();
    }

    private void OnDestroy()
    {
        _closeButton.clicked -= CloseShop;
        _gridManager.ClearSubscriptions();
    }

    #endregion

    #region Setup Methods

    private void SetupManagers()
    {
        _shopManager = new ShopActivitiesManager(_coinsLabel);

        _gridManager = new ShopGridManager(_grid, skinCellTemplate, _shopManager);
        _gridManager.Initialize();
    }

    private void SetupCoins()
    {
        _coinsLabel.text = $"Coins: {GameDataManager.Instance.PlayerData.Coins}";
    }

    private void SetupSceneManagement()
    {
        _closeButton.clicked += CloseShop;
    }

    #endregion

    private void CloseShop() => _sceneManagerService.UnloadCurrentScene();

}
