using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger3 : MonoBehaviour
{
    private SpriteRenderer tip3;
    private GameObject dialogBox3;

    [HideInInspector]
    public Ctrl ctrl;

    public Sprite stay,conduct;

    void Start()
    {
        tip3=GameObject.Find("Model/NPC/MysteriousMan/tip").GetComponent<SpriteRenderer>();

        dialogBox3=GameObject.Find("View/Canvas/DialogueSystem/DialogBox (3)");
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            tip3.GetComponent<SpriteRenderer>().sprite=conduct;
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
        }
    }
}
