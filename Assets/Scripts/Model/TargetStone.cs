using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetStone : MonoBehaviour
{
    public float duration;
    public float fallX;
    public float fallY;
    private Transform trans;
    private bool canFall;


    private Vector2 firstPosition;

    void Start()
    {
        canFall = true;

        trans = this.gameObject.transform;

        firstPosition = transform.position;
    }

    void FallMethod()
    {
        trans.DOMove(trans.position + new Vector3(fallX,fallY,0),duration);

    }

    private void OnTriggerEnter2D(Collider2D other)
     {
        if(other.gameObject.tag == "Player" && canFall)
        {
            FallMethod();
            canFall=false;
        }
     }

    public void InitializationTarget()
    {
        transform.position = firstPosition;
        canFall = true;

        trans.DOPause();// 暂停动画，使得以上可以进行位置的刷新
    }

}