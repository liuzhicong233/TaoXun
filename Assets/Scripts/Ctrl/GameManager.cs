using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private bool isPause=false;
    private GameObject player;
    private PlayerData playerData;


    private void Awake() {
        player=GameObject.Find("Ctrl/Player");
        playerData=player.GetComponent<PlayerData>();

    }

    
    public void DisableMove(){
        player.GetComponent<Player2D>().enabled=false;
    }
    public void EnableMove(){
        player.GetComponent<Player2D>().enabled=true;
    }
    public void PauseTime(){
        Time.timeScale=0f;
    }
    public void ContinueTime(){
        Time.timeScale=1f;
    }
    public void Initialize(){
        player.transform.position=new Vector3(0,-2f,0);
        playerData.Save();
    }

}
