using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueT2 : MonoBehaviour
{
    private GameObject dialogBox5;
    void Start()
    {
        dialogBox5=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (5)");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            dialogBox5.SetActive(true);
            Invoke("DisableAfterTouch",1f);
        }
    }
    void DisableAfterTouch(){
        gameObject.SetActive(false);
    }
}
