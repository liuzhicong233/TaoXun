using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueT1 : MonoBehaviour
{
    private GameObject dialogBox4;
    void Start()
    {
        dialogBox4=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (4)");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            dialogBox4.SetActive(true);
            Invoke("DisableAfterTouch",1f);
        }
    }
    void DisableAfterTouch(){
        gameObject.SetActive(false);
    }
}
