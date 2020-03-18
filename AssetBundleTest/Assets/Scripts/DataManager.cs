using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    //public ObjectData Data;
    public string file = "player.txt";
    public void Save()
    {
       // string json = JsonUtility.ToJson(Data);
        //WriteForFile(file, json);
    }

    public void Load()
    {
       // Data = new ObjectData();
        string json = ReadFromFile(file);
        //JsonUtility.FromJsonOverwrite(json, Data);
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
