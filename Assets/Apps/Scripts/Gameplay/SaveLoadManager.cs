using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public string lastSignIn;
}

public class SaveLoadManager : MonoBehaviour
{
    public GameData gameData;

    public void Save()
    {
        if (gameData is null)
        {
            Debug.Log("No game data!");
            return;
        }
        
        string json = JsonUtility.ToJson(gameData);
        string filename = "data.simpan";
        string path = Application.persistentDataPath + filename;
        System.IO.File.WriteAllText(path: path, contents: json);
    }

    public void Load()
    {
        string filename = "data.simpan";
        string path = Application.persistentDataPath + filename;
        string json = System.IO.File.ReadAllText(path);
        
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
