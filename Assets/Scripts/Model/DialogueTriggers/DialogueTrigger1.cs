using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger1 : MonoBehaviour
{
    private SpriteRenderer tip1;
    private GameObject dialogBox1;

    [HideInInspector]
    public Ctrl ctrl;

    public Sprite stay,conduct;

    void Start()
    {
        tip1=GameObject.Find("Model/InteractionPoints/NPC/Climber/tip").GetComponent<SpriteRenderer>();

        dialogBox1=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (1)");

        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="Climber"){
            tip1.GetComponent<SpriteRenderer>().sprite=conduct;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(gameObject.tag=="Climber"){
            tip1.GetComponent<SpriteRenderer>().sprite=stay;
        }
    }
    void Update()
    {
        if(tip1.GetComponent<SpriteRenderer>().sprite==conduct&&Input.GetKeyDown(KeyCode.R)){
            dialogBox1.SetActive(true);

            ctrl.gameManager.DisableMove();// 禁用移动
            ctrl.cameraManager.DialogueNarrow();// 拉近视角

            ctrl.playState.canPause = false;// 在对话时禁止按暂停

        }
    }
}
