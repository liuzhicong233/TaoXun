using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableTerrain : MonoBehaviour
{
    private Animator animator;

    private Ctrl ctrl;

    private bool canTrigger;// 作为是否可以触发的条件

    private void Start() {
        animator=GetComponent<Animator>();

        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();

        canTrigger = true;// 开始时默认设置为true
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(canTrigger){// 如果可以触发  
            Invoke("DisableTerrain",0.75f);
            Invoke("PlayAnimation",0.5f);

            canTrigger = false;// 在进行第一次碰撞时将其设置为false。因为我们的操作要延迟一段时间后执行，而玩家有可能在这段时间再次踩到石块，所以要确保只执行一次
        }

    }
    void DisableTerrain(){
        animator.enabled=false;
        this.gameObject.SetActive(false);

        canTrigger = true;// 执行完再将其设置为true
    }
    void PlayAnimation(){
        animator.enabled=true;
        ctrl.audioManager.StoneBreakAudio();
    }
}
