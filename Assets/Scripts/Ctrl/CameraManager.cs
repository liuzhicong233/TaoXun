using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    private Animator animator;

    private void Awake() {
        animator=cinemachine.GetComponent<Animator>();
    }
    public void Enlarge(){
        animator.SetBool("isPlay",false);
    }
    public void Narrow(){
        animator.SetBool("isPlay",true);
        animator.SetBool("isDialog",false);
    }
    public void DialogueNarrow(){
        animator.SetBool("isDialog",true);
    }
}
