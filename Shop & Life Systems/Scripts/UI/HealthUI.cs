using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Handles the visual representation of the player's health system.
/// 
/// Responsible for generating the heart UI dynamically, updating heart states,
/// and reacting to health changes through events from the PlayerHealthManager.
/// </summary>

public class HealthUI: MonoBehaviour
{
    [SerializeField] private HandlerUI rootUI;
    [SerializeField] private VisualTreeAsset heartTemplate;
    [SerializeField] private Texture heartSprite;
    [SerializeField] private Texture emptyHeartSprite;

    private VisualElement _rootElement;
    private VisualElement _heartContainer;
    private readonly List<Image> _hearts = new();

    private PlayerHealthManager _healthManager;
    private int _maxHealth;

    #region Unity Life Cycle

    private void Start()
    {
        _healthManager = PlayerHealthManager.Instance;
        _maxHealth = _healthManager.GetMaxHealth();
        
        _rootElement = rootUI.GetRootElement();
        _heartContainer = _rootElement.Q<VisualElement>("HeartsContainer");

        CreateHearts();
    }

    private void OnEnable()
    {
        PlayerHealthManager.OnHealthUpdated += UpdateHealth;
    }

    private void OnDisable()
    {
        PlayerHealthManager.OnHealthUpdated -= UpdateHealth;
    }

    #endregion

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].image = i < currentHealth ? heartSprite : emptyHeartSprite;
        }
    }

    private void CreateHearts()
    {
        _heartContainer.Clear();
        _hearts.Clear();

        for (int i = 0; i < _maxHealth; i++)
        {
            TemplateContainer heart = heartTemplate.CloneTree();

            Image image = heart.Q<Image>("Heart");
            image.image = heartSprite;

            _heartContainer.Add(heart);
            _hearts.Add(image);
        }
    }
}
