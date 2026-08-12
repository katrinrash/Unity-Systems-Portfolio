using UnityEngine;
using UnityEngine.U2D.Animation;

/// <summary>
/// Scriptable Object containing configuration data for a single skin.
/// 
/// Stores all information required to display, purchase, and apply a skin,
/// including identification data, visual assets, animation library reference,
/// and economy-related values.
/// </summary>

[CreateAssetMenu(fileName = "SkinSO", menuName = "Scriptable Objects/SkinSO")]
public class SkinDataSO : ScriptableObject
{
    [Header("Identity")]
    [field: SerializeField] public int Id { get; private set; }
    [field: SerializeField] public SkinCell SkinCell { get; private set; }

    [Header("Visual")]
    [field: SerializeField] public Sprite SkinSprite { get; private set; }
    [field: SerializeField] public SpriteLibraryAsset SpriteLibrary { get; private set; }

    [Header("Economy")]
    [field: SerializeField] public int Price { get; private set; } 

    public void SetCell(SkinCell skinCell)
    {
        SkinCell = skinCell;
    }

}
