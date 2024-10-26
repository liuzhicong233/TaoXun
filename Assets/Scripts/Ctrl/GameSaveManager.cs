using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    public Player2D player2D;

    public void SaveGame(){


        if(!Directory.Exists(Application.persistentDataPath + "/game_SaveData")){
            Directory.CreateDirectory(Application.persistentDataPath+"/game_SaveData");
        }

        BinaryFormatter formatter=new BinaryFormatter();// 二进制转化

        FileStream file=File.Create(Application.persistentDataPath+"/game_SaveData/TaoXun.txt");

        var json=JsonUtility.ToJson(player2D);

        formatter.Serialize(file,json);

        file.Close();
    }
    public void LoadGame(){
        BinaryFormatter bf=new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath+"/game_SaveData/TaoXun.txt")){
            FileStream file=File.Open(Application.persistentDataPath+"/game_SaveData/TaoXun.txt",FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),player2D);

            file.Close();
        }
    }
}
