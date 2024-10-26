    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float moveRateX;
    public float moveRateY;
    private float startPointX,startPointY;
    void Start()
    {
        startPointX = transform.position.x;
        startPointY = transform.position.y;
    }

    void FixedUpdate()
    {
        transform.position=new Vector2(startPointX + cam.position.x * moveRateX,transform.position.y);
        transform.position=new Vector2(transform.position.x,startPointY + cam.position.y * moveRateY);
    }
}
