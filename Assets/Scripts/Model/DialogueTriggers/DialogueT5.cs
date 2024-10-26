using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueT5 : MonoBehaviour
{
    private GameObject dialogBox8;
    void Start()
    {
        dialogBox8=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (8)");

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            dialogBox8.SetActive(true);
            Invoke("DisableAfterTouch",1f);
        }
    }
    void DisableAfterTouch(){
        gameObject.SetActive(false);
    }
}
