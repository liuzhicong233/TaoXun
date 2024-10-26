using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public GameObject follow;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            follow.GetComponent<Follow>().canFollow = true;// 若玩家碰到这个区域（追踪判断范围），那么开始追踪
        }
    }
}
