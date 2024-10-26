using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueT3 : MonoBehaviour
{
    private GameObject dialogBox6;

        private Player2D player2D;
    void Start()
    {
        dialogBox6=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (6)");

        player2D=GameObject.Find("Ctrl/Player").GetComponent<Player2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            dialogBox6.SetActive(true);
            Invoke("DisableAfterTouch",1f);

            player2D.canGlide=true;// 将滑翔设置为可以使用（碰到气流后）

        }
    }
    void DisableAfterTouch(){
        gameObject.SetActive(false);
    }
}
