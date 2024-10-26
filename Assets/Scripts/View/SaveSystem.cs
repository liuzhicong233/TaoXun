using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    public static void SaveByPlayerPrefs(string key,object data)
    {
        var json=JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key,json);
        PlayerPrefs.Save();
    }
    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key,null);
    }
}
