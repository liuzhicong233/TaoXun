using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ToHitStoneMove : MonoBehaviour
{
    private Transform playerTransform;
    private GameObject player;
    private Transform trans;

    private Tweener moveLeft;

    public float speed;

    public float duration;

    private Ctrl ctrl;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;// 指定一下player原来位置的parent

        player = GameObject.FindGameObjectWithTag("Player");

        trans = this.gameObject.transform;
        trans.DOMove(trans.position + new Vector3(speed,0,0),duration).SetLoops(-1, LoopType.Yoyo);

        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();
        
    }

    private void OnCollisionEnter2D(Collision2D other) {// 在与这个石块发生碰撞时就将player设置为它的子物体，可以跟着它移动
        if(other.gameObject.tag == "Player"){
             other.gameObject.transform.parent = gameObject.transform;

        }

    }

    private void OnCollisionExit2D(Collision2D other) {// 离开碰撞时恢复回去
        if(other.gameObject.tag == "Player" && other.gameObject.activeInHierarchy){
             other.gameObject.transform.parent = playerTransform;

        }
    }


}
