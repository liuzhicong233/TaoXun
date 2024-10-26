using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchivePointEnable : MonoBehaviour
{
    private Player2D player2D;


    private void Start() {
        player2D=GameObject.Find("Ctrl/Player").GetComponent<Player2D>();


    }
    private void OnTriggerEnter2D(Collider2D other) {
        player2D.canSave=true; 
    }
    private void OnTriggerStay2D(Collider2D other) {
        gameObject.GetComponent<Animator>().enabled=true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        player2D.canSave=false;
    }
}
