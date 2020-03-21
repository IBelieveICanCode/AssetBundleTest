using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class DataManager : MonoBehaviour
{
    public PlayerData PlayerData;
    private string file = "figureData.txt";

    public void Save()
    {
       string json = JsonUtility.ToJson(PlayerData);
       WriteForFile(file, json);
    }

    #if UNITY_EDITOR
    public void SaveAssetBundles()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach (string name in names)
        {
            PlayerData.AssetNames.Add(name);
        }
        Save();
    }
    #endif

    public void Load()
    {
        PlayerData = new PlayerData();
        string json = ReadFromFile(file);
        print("json: " + json);
        JsonUtility.FromJsonOverwrite(json, PlayerData);
    }

    private void WriteForFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File does not exist");
        return "";
    }
    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

[System.Serializable]
public class PlayerData
{
    public List<string> AssetNames;
}