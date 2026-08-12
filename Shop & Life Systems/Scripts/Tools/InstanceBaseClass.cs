using UnityEngine;

/// <summary>
/// Base class providing Singleton functionality for MonoBehaviour components.
/// 
/// Ensures that only one instance of a derived manager exists during runtime
/// and provides global access through the Instance property.
/// 
/// Used for persistent game-wide systems that require a single shared instance,
/// such as managers responsible for game data, scene management, or player state.
/// </summary>

[DisallowMultipleComponent]
public abstract class InstanceBaseClass<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }    
        
        Instance = this as T;
        OnInstanceBaseClassAwake();
    }

    protected virtual void OnInstanceBaseClassAwake() { }

}