using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblingStone : MonoBehaviour
{
    private Transform playerTransform;

    private Transform trans;
    private float finalY;
    private float fy;
    public float fallSpeed;
    private Collider2D simulation;



    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;// 指定一下player原来位置的parent

        trans=GetComponent<Transform>();
        simulation=GetComponentsInChildren<Collider2D>()[0];

    }
    private void Update()
    {
        // finalY=trans.position.y;
        // fallMethod();
        // if(finalY==-30)
        // {
        //     fy=trans.position.y;
        //     fy=30;
        // }

        
            fallMethod();

    }
    void fallMethod()
    {
        trans.Translate(Vector2.down*Time.deltaTime*fallSpeed);
        simulation.enabled=true;

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
