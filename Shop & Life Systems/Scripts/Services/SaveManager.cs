using System.IO;
using UnityEngine;

/// <summary>
/// Manages serialization and persistence of player data.
/// 
/// Converts player data into a JSON format for saving and restores it
/// when loading previous game progress.
/// </summary>

public class SaveManager
{
    private readonly string path = Application.persistentDataPath + "/player.json";

    public void SavePlayerData(PlayerDataSave data)
    {
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);
    }

    public PlayerData LoadPlayerData()
    {
        string json = File.ReadAllText(path);
        PlayerDataSave saveData = JsonUtility.FromJson<PlayerDataSave>(json);

        return saveData.ToPlayerData();
    }

    public bool ValidSave() => File.Exists(path);

}
