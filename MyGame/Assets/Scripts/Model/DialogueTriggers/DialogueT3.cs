using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueT3 : MonoBehaviour
{
    private GameObject dialogBox6;
    void Start()
    {
        dialogBox6=GameObject.Find("View/Canvas/DialogueSystem/DialogBox (6)");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            dialogBox6.SetActive(true);
            Invoke("DisableAfterTouch",1f);
        }
    }
    void DisableAfterTouch(){
        gameObject.SetActive(false);
    }
}
