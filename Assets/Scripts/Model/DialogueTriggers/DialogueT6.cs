using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueT6 : MonoBehaviour
{
    private GameObject dialogBox9;
    void Start()
    {
        dialogBox9=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (9)");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            dialogBox9.SetActive(true);
            Invoke("DisableAfterTouch",1f);
        }
    }
    void DisableAfterTouch(){
        gameObject.SetActive(false);
    }
}
