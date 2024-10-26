using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger3 : MonoBehaviour
{
    private SpriteRenderer tip3;
    private GameObject dialogBox3;

    private Player2D player2D;

    [HideInInspector]
    public Ctrl ctrl;

    public Sprite stay,conduct;

    void Start()
    {
        tip3=GameObject.Find("Model/InteractionPoints/NPC/MysteriousMan/tip").GetComponent<SpriteRenderer>();

        dialogBox3=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (3)");
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();

        player2D=GameObject.Find("Ctrl/Player").GetComponent<Player2D>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            tip3.GetComponent<SpriteRenderer>().sprite=conduct;

            player2D.canJumpTwice=true;// 将二段跳设置为可以使用（遇到高岭深士后）
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            tip3.GetComponent<SpriteRenderer>().sprite=stay;
        }
    }
    void Update()
    {
        if(tip3.GetComponent<SpriteRenderer>().sprite==conduct&&Input.GetKeyDown(KeyCode.R)){
            dialogBox3.SetActive(true);

            ctrl.gameManager.DisableMove();// 禁用移动
            ctrl.cameraManager.DialogueNarrow();// 拉近视角

            ctrl.playState.canPause = false;// 在对话时禁止按暂停


        }
    }
}
