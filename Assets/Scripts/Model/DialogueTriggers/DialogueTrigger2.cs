using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    private SpriteRenderer tip2;
    private GameObject dialogBox2;

    [HideInInspector]
    public Ctrl ctrl;

    private Player2D player2D;
    public Sprite stay,conduct;

    void Start()
    {
        tip2=GameObject.Find("Model/InteractionPoints/NPC/Pilot/tip").GetComponent<SpriteRenderer>();

        dialogBox2=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (2)");
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();

        player2D=GameObject.Find("Ctrl/Player").GetComponent<Player2D>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="Pilot"){
            tip2.GetComponent<SpriteRenderer>().sprite=conduct;
            player2D.canSprint=true;// 把冲刺设置为可以使用（遇到飞行员后）
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(gameObject.tag=="Pilot"){
            tip2.GetComponent<SpriteRenderer>().sprite=stay;
        }
    }
    void Update()
    {
        if(tip2.GetComponent<SpriteRenderer>().sprite==conduct&&Input.GetKeyDown(KeyCode.R)){
            dialogBox2.SetActive(true);

            ctrl.gameManager.DisableMove();// 禁用移动
            ctrl.cameraManager.DialogueNarrow();// 拉近视角

            ctrl.playState.canPause = false;// 在对话时禁止按暂停


        }
    }
}
