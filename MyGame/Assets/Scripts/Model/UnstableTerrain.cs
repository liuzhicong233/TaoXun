using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableTerrain : MonoBehaviour
{
    private Animator animator;
    private void Start() {
        animator=GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Invoke("DisableTerrain",0.75f);
        Invoke("PlayAnimation",0.5f);
    }
    void DisableTerrain(){
        this.gameObject.SetActive(false);
    }
    void PlayAnimation(){
        animator.enabled=true;
    }
}
