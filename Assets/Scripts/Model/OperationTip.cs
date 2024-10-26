using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationTip : MonoBehaviour
{
    [HideInInspector]
    public Ctrl ctrl;

    private void Start() {
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.tag=="SpaceTip"){
            ctrl.view.ShowSpaceTip();
        }
        if(gameObject.tag=="ClimbWallTip"){
            ctrl.view.ShowClimbWallTip();
        }
        if(gameObject.tag=="SprintTip"){
            ctrl.view.ShowSprintTip();
        }
        if(gameObject.tag=="GlideTip"){
            ctrl.view.ShowGlideTip();
        }
        if(gameObject.tag=="SaveTip"){
            ctrl.view.ShowSaveTip();
        }
        if(gameObject.tag=="JumpTwiceTip"){
            ctrl.view.ShowJumpTwiceTip();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(gameObject.tag=="SpaceTip"){
            ctrl.view.HideSpaceTip();
        }
        if(gameObject.tag=="ClimbWallTip"){
            ctrl.view.HideClimbWallTip();
        }
        if(gameObject.tag=="SprintTip"){
            ctrl.view.HideSprintTip();
        }
        if(gameObject.tag=="GlideTip"){
            ctrl.view.HideGlideTip();
        }
        if(gameObject.tag=="SaveTip"){
            ctrl.view.HideSaveTip();
        }
        if(gameObject.tag=="JumpTwiceTip"){
            ctrl.view.HideJumpTwiceTip();
        }
    }

}
