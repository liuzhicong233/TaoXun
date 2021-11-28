using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    private Transform trans;
    private float initialY;
    private float changeY;
    public float fallSpeed;
    public float riseSpeed;
    private bool canFall;
    private bool canRise;
    private Collider2D simulation;

    private void Start() {
        trans=GetComponent<Transform>();
        initialY=trans.position.y;

        simulation=GetComponentInChildren<CapsuleCollider2D>();
    }
    private void Update() {
        changeY=trans.position.y;
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
}
