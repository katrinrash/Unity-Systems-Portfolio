using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Scriptable Object database that stores all available skin configurations.
/// 
/// Provides centralized access to skin data and allows new skins to be added
/// without modifying the existing gameplay logic.
/// </summary>

[CreateAssetMenu(fileName = "SkinDatabase", menuName = "Scriptable Objects/Skin Database")]
public class SkinDatabaseSO : ScriptableObject
{
    [field: SerializeField] public List<SkinDataSO> Skins { get; private set; } = new();

    public SkinDataSO GetSkin(int id)
    {
        return Skins.Find(x => x.Id == id);
    }

}
