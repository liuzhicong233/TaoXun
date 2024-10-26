using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    private Transform playerTransform;
    private Transform trans;
    private float initialY;
    private float changeY;
    public float fallSpeed;
    public float riseSpeed;
    private bool canFall;
    private bool canRise;
    private Collider2D simulation;


    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;// 指定一下player原来位置的parent

        trans=GetComponent<Transform>();
        initialY=trans.position.y;

        simulation=GetComponentInChildren<CapsuleCollider2D>();

    }
    private void Update() {
        changeY=trans.position.y-5;
        if(canFall&&initialY-changeY<=5){
            trans.Translate(Vector2.down*Time.deltaTime*fallSpeed);
            simulation.enabled=true;
        }else{
            canRise=true;
            canFall=false;
        }
        if(canRise&&initialY-changeY>=0){
            trans.Translate(Vector2.up*Time.deltaTime*riseSpeed);
            simulation.enabled=false;
        }else{
            canRise=false;
            canFall=true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {// 在与这个石块发生碰撞时就将player设置为它的子物体，可以跟着它移动
        if(other.gameObject.tag == "Player"){
             other.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {// 离开碰撞时恢复回去
        if(other.gameObject.tag == "Player"){
             other.gameObject.transform.parent = playerTransform;
        }
    }
}
