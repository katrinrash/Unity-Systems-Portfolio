using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// Handles the Game Over popup UI.
/// 
/// Responsible for displaying the popup when the player loses all lives,
/// managing UI button interactions, and communicating with gameplay systems
/// through events.
/// </summary>

public class GameOverUI : MonoBehaviour 
{
    [SerializeField] private HandlerUI rootUI;
    
    private VisualElement _rootElement;
    private VisualElement _popup;
    private Button _restartButton;
    private Button _menuButton;
    private Button _watchAdButton;

    #region Unity Life Cycle

    private void Start()
    {
        _rootElement = rootUI.GetRootElement();

        _popup = _rootElement.Q<VisualElement>("LosePopup");
        _restartButton = _rootElement.Q<Button>("RestartButton");
        _menuButton = _rootElement.Q<Button>("BackButton");
        _watchAdButton = _rootElement.Q<Button>("RewardButton");

        Subscribe();
    }

    private void Subscribe()
    {
        PlayerHealthManager.OnPlayerDeath += Show;
        
        _restartButton.clicked += Restart;
        _menuButton.clicked += GoToMenu;
        _watchAdButton.clicked += WatchAd;
    }

    private void OnDestroy()
    {
        PlayerHealthManager.OnPlayerDeath -= Show;

        _restartButton.clicked -= Restart;
        _menuButton.clicked -= GoToMenu;
        _watchAdButton.clicked -= WatchAd;
    }

    #endregion

    #region Popup Management

    public void Show()
    {
        _popup.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        _popup.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
    }

    #endregion

    #region Popup Options 

    private void WatchAd()
    {
        // After player watched the ad
        Hide();
        PlayerHealthManager.Instance.RestoreHealth();
    }

    private void Restart()
    {
        Hide();
        SceneManagerService.Instance.LoadNewScene(SceneManager.GetActiveScene().name);
    }

    private void GoToMenu()
    {
        Hide();
        SceneManagerService.Instance.LoadNewScene(0);
    }

    #endregion
}
