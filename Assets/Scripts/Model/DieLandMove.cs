using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DieLandMove : MonoBehaviour
{
    private Transform theTrans;
    private float initialY;
    private float initialX;
    private float changeY;
    private float changeX;

    private bool canDown;
    private bool canUp;
    private bool canLeft;
    private bool canRight;
    public float hSpeed;
    public float vSpeed;
    
    public bool[] trans;
    void Start()
    {
        theTrans=gameObject.transform;

        initialY=theTrans.position.y;
        initialX=theTrans.position.x;
    }

    void Update()
    {
        if(trans[0]){
            FromUpToDown();
        }
        if(trans[1]){
            FromDownToUp();
        }
        if(trans[2]){
            FromLeftToRight();
        }
        if(trans[3]){
            FromRightToLeft();
        }
    }
    void FromUpToDown(){
        changeY=theTrans.position.y;

        if(canDown&&initialY-changeY<=5){
            theTrans.DOMove(theTrans.position+new Vector3(0,-vSpeed,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=false;
        }else{
            canUp=true;
            canDown=false;
        }
        if(canUp&&initialY-changeY>=0){
            theTrans.DOMove(theTrans.position+new Vector3(0,vSpeed,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=true;
        }else{
            canDown=true;
            canUp=false;
        }
    }
    void FromDownToUp(){
        changeY=theTrans.position.y;

        if(canDown&&initialY-changeY>=-5){
            theTrans.DOMove(theTrans.position+new Vector3(0,vSpeed,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=false;

        }else{
            canUp=true;
            canDown=false;
        }
        if(canUp&&initialY-changeY<=0){
            theTrans.DOMove(theTrans.position+new Vector3(0,-vSpeed,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=true;
        }else{
            canDown=true;
            canUp=false;
        }
    }
    void FromLeftToRight(){
        changeX=theTrans.position.x;

        if(canRight&&initialX-changeX>=-10){
            theTrans.DOMove(theTrans.position+new Vector3(hSpeed,0,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=false;
        }else{
            canLeft=true;
            canRight=false;
        }
        if(canLeft&&initialX-changeX<=0){
            theTrans.DOMove(theTrans.position+new Vector3(-hSpeed,0,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=true;
        }else{
            canRight=true;
            canLeft=false;
        }
    }
    void FromRightToLeft(){
        changeX=theTrans.position.x;

        if(canLeft&&initialX-changeX<=10){
            theTrans.DOMove(theTrans.position+new Vector3(-hSpeed,0,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=false;
        }else{
            canRight=true;
            canLeft=false;
        }
        if(canRight&&initialX-changeX>=0){
            theTrans.DOMove(theTrans.position+new Vector3(hSpeed,0,0),4f);
            theTrans.gameObject.GetComponent<SpriteRenderer>().flipY=true;
        }else{
            canLeft=true;
            canRight=false;
        }
    }
    
}
