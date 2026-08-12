using UnityEngine;
using UnityEngine.U2D.Animation;

/// <summary>
/// Handles applying the currently selected player skin to the character visual components.
/// 
/// Retrieves skin data from the GameDataManager and updates the character appearance,
/// including the sprite and animation library used by the Sprite Resolver system.
/// </summary>

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSkinManager : MonoBehaviour
{
    [SerializeField] private SpriteLibrary spriteLibrary;
    
    private GameDataManager gameDataManager;
    private SpriteRenderer _spriteRenderer;

    #region Unity Lifecycle

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        gameDataManager = GameDataManager.Instance;
        UpdateSkin();
    }

    private void OnEnable()
    {
        gameDataManager.PlayerData.OnSkinUpdated += UpdateSkin;
    }

    private void OnDisable()
    {
        gameDataManager.PlayerData.OnSkinUpdated -= UpdateSkin;
    }

    #endregion

    private void UpdateSkin()
    {
        SkinDataSO skin = gameDataManager.GetCurrentSkinData();

        if(spriteLibrary)
            spriteLibrary.spriteLibraryAsset = skin.SpriteLibrary;
        
        _spriteRenderer.sprite = skin.SkinSprite;
    }

}
