using System;
using UnityEngine;

/// <summary>
/// Global manager responsible for handling the player's health/life system.
/// 
/// Controls the current health state, manages losing and restoring lives,
/// and notifies other systems about health changes and player death through events.
/// </summary>

public class PlayerHealthManager : InstanceBaseClass<PlayerHealthManager>
{
    public static Action<int> OnHealthUpdated;
    public static Action OnPlayerDeath;

    [SerializeField] private int defaultHealth = 3;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = defaultHealth;
    }

    #region Health Management

    public void ReduceHealth()
    {
        if (_currentHealth <= 0)
            return;

        _currentHealth--;
        CheckState();
    }

    public void RestoreHealth()
    {
        if (_currentHealth >= defaultHealth)
            return;

        _currentHealth++;
        CheckState();
    }

    private void CheckState()
    {
        OnHealthUpdated?.Invoke(_currentHealth);

        if(_currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    #endregion

    public int GetMaxHealth() => defaultHealth;
}
