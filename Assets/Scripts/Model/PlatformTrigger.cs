using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private GameObject player;

    private void Start() {
        player = GameObject.Find("Ctrl/Player");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Stand"){
            player.GetComponent<Collider2D>().enabled = false;
        }
    }
}
