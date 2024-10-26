using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueT4 : MonoBehaviour
{
    private GameObject dialogBox7;


    void Start()
    {
        dialogBox7=GameObject.Find("View/GameCanvas/DialogueSystem/DialogBox (7)");

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="MysteriousMan"){
            dialogBox7.SetActive(true);
            Invoke("DisableAfterTouch",1f);

        }
    }
    void DisableAfterTouch(){
        gameObject.SetActive(false);
    }
}
