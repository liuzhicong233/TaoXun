using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger10 : MonoBehaviour
{
    private SpriteRenderer tip10;
    private GameObject dialogBox3;

    private Player2D player2D;

    [HideInInspector]
    public Ctrl ctrl;

    public Sprite stay,conduct;

    void Start()
    {
        tip10=GameObject.Find("Model/InteractionPoints/Dialoger/MysteriousMan/tip").GetComponent<SpriteRenderer>();

        dialogBox3=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (10)");
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();

        player2D=GameObject.Find("Ctrl/Player").GetComponent<Player2D>();

    }

    private void OnEnable() {
        EventHandle.GameFinishEvent += OnGameFinishEvent;
    }
    private void OnDisable(){
        EventHandle.GameFinishEvent -= OnGameFinishEvent;
    }

    private void OnGameFinishEvent()
    {
        StartCoroutine(StartDialogue());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            tip10.GetComponent<SpriteRenderer>().sprite = conduct;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            tip10.GetComponent<SpriteRenderer>().sprite = stay;
        }
    }
    // void Update()
    // {
    //     if(tip10.GetComponent<SpriteRenderer>().sprite == conduct && Input.GetKeyDown(KeyCode.R)){
    //         dialogBox3.SetActive(true);

    //         ctrl.gameManager.DisableMove();// 禁用移动
    //         ctrl.cameraManager.DialogueNarrow();// 拉近视角

    //         ctrl.playState.canPause = false;// 在对话时禁止按暂停


    //     }
    // }

    IEnumerator StartDialogue(){
        ctrl.gameManager.DisableMove();// 禁用移动
        
        yield return new WaitForSeconds(4f);

        dialogBox3.SetActive(true);


        ctrl.playState.canPause = false;// 在对话时禁止按暂停

    }
}
