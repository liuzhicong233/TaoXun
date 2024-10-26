using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [System.Serializable]class SaveData
    {
        public Vector3 playerPosition;

    }
    public void Save()
    {
        SaveByPlayerPrefs();
    }
    public void Load()
    {
        LoadFromPlayerPrefs();
    }
    void SaveByPlayerPrefs()
    {
        var saveData=new SaveData();

        saveData.playerPosition = transform.position;

        SaveSystem.SaveByPlayerPrefs("PlayerData",saveData);
    }
    void LoadFromPlayerPrefs()
    {
        var json=SaveSystem.LoadFromPlayerPrefs("PlayerData");
        var SaveData=JsonUtility.FromJson<SaveData>(json);

        transform.position = SaveData.playerPosition;

        gameObject.SetActive(true);// 将player激活

    }
    public void DeletePlayerDatePrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void InactivationPlayer(){
        gameObject.SetActive(false);
    }
}
