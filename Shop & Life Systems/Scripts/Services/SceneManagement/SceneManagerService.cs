using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Global service responsible for managing scene transitions throughout the game.
/// 
/// Provides centralized scene loading functionality, including standard and
/// additive scene loading workflows. Handles switching between gameplay and
/// independent scene modules while preserving the application state.
/// </summary>

public class SceneManagerService : InstanceBaseClass<SceneManagerService>
{
    private GameDataManager _gameDataManager;
    private GameplayRootManager _rootManager;
    private Scene _currentScene;

    protected override void OnInstanceBaseClassAwake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
    }

    public void SetRootSceneObject(GameplayRootManager rootSceneObject)
    {
        _rootManager = rootSceneObject;
    }

    #region Load Scene Methods

    public void LoadNewScene(string sceneName)
    {
         SceneManager.LoadScene(sceneName);
    }

    public void LoadNewScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    #endregion

    #region Additive Loading Wrappers

    public async void LoadAdditiveScene(string sceneName)
    {
        await LoadAdditive(sceneName);
    }

    public async void LoadAdditiveScene(int sceneID)
    {
        await LoadAdditive(sceneID);
    }

    public async void UnloadCurrentScene()
    {
        await Unload();
    }

    #endregion

    #region Load Additive Scene Methods

    private async Task LoadAdditive(string sceneName)
    {
        _rootManager.DisableRoot();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        _currentScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(_currentScene);
    }

    private async Task LoadAdditive(int sceneID)
    {
        _rootManager.DisableRoot();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        _currentScene = SceneManager.GetSceneByBuildIndex(sceneID);
        SceneManager.SetActiveScene(_currentScene);

    }

    #endregion

    #region Unload Scene Methods

    private async Task Unload()
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(_currentScene.name);

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        _gameDataManager.SaveGameData();
        _rootManager.EnableRoot();
    }

    #endregion

}
