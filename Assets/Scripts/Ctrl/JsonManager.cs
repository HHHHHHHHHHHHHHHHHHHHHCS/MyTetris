using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonManager
{
    private const string fileName = "data.json";
    private string filePath;

    public JsonManager Init()
    {
        #if UNITY_ANDROID
            filePath = string.Format("{0}/{1}", Application.persistentDataPath, fileName);
        #elif UNITY_IPHONE
            filePath = string.Format("{0}/{1}", Application.persistentDataPath, fileName);
        #else
                filePath = string.Format("{0}/{1}", Application.dataPath, fileName);
        #endif
        return this;
    }


    public string Read()
    {
        string result = "";
        if (File.Exists(filePath))
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                result = sr.ReadToEnd();

            }
        }
        return result;
    }


    public SaveData GetData()
    {
        var data = JsonConvert.DeserializeObject<SaveData>(Read());
        if(data==null)
        {
            data = new SaveData();
        }
        return data;
    }

    public string Save(SaveData data)
    {
        string jsonStr = JsonConvert.SerializeObject(data);
        using (StreamWriter sw = File.CreateText(filePath))
        {
            sw.Write(jsonStr);
        }
        return jsonStr;
    }

    public string UpdateData(SaveData saveData)
    {
        return Save(saveData);
    }
}
