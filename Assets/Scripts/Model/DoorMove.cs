using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorMove : MonoBehaviour
{
    private Transform theTrans;
    void Start()
    {
        theTrans=gameObject.transform;
    }
    public void DoorMoveUp()
    {
        theTrans.DOMove(theTrans.position+new Vector3(0,5f,0),4f);
    }
    public void DoorMoveDown()
    {
        theTrans.DOMove(theTrans.position+new Vector3(0,-5f,0),4f);
    }
    public void DoorMoveleft()
    {
        theTrans.DOMove(theTrans.position+new Vector3(-5f,0,0),4f);
    }
    public void DoorMoveRight()
    {
        theTrans.DOMove(theTrans.position+new Vector3(5f,0,0),4f);
    }
}
