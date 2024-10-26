using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private SpriteRenderer tip;
    private GameObject dialogBox;

    [HideInInspector]
    public Ctrl ctrl;
    public Sprite stay,conduct;
    private void Start() {
        tip=GameObject.Find("Model/InteractionPoints/NPC/OldMan/tip").GetComponent<SpriteRenderer>();

        dialogBox=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox");
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();


    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="OldMan"){
            tip.GetComponent<SpriteRenderer>().sprite=conduct;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(gameObject.tag=="OldMan"){
            tip.GetComponent<SpriteRenderer>().sprite=stay;
        }
    }
    private void Update() {
        if(tip.GetComponent<SpriteRenderer>().sprite==conduct&&Input.GetKeyDown(KeyCode.R)){
            dialogBox.SetActive(true);

            ctrl.gameManager.DisableMove();// 禁用移动
            ctrl.cameraManager.DialogueNarrow();// 拉近视角

            ctrl.playState.canPause = false;// 在对话时禁止按暂停
            
        }
    }
}
