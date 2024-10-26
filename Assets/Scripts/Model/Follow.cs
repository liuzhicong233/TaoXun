using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;//被跟随的Player
    public float speed;//追踪速度
    private Vector2 direction;//一个二维坐标
    private Vector2 firstPosition; // 开始位置

    [HideInInspector]
    public bool canFollow;// 是否可以追踪玩家
    void Start()
    {
        firstPosition = transform.position;// 记录开始位置

        canFollow = false;// 开始将其设置为false
    }
    void FixedUpdate()// 固定帧调用追踪
    {
        if(canFollow){
            StartCoroutine(FollowTime());
        }
    }

    private void OnEnable() {
        EventHandle.PlayerDieEvent += OnPlayerDieEvent;
    }


    private void OnDisable() {
        EventHandle.PlayerDieEvent -= OnPlayerDieEvent;
        
    }
    private void OnPlayerDieEvent()
    {
        RestoreFollow();
    }

    private void FollowPlayer(){
        direction = player.position - transform.position;//玩家与小球的位置差，得到一个指向玩家的向量
        direction.Normalize();//单位化向量
        transform.Translate(direction  * speed * Time.deltaTime);

        this.GetComponent<Animator>().enabled = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")// 如果追踪物碰到玩家
        {
            RestoreFollow();
        }
    }
    public void InitializationFollow()
    {
        transform.position = firstPosition;
        this.gameObject.SetActive(true);
        this.GetComponent<Animator>().enabled = false;
        this.transform.localScale = Vector3.one;
    }

    IEnumerator FollowTime(){

        FollowPlayer();
        yield return new WaitForSeconds(4.99f);

        this.gameObject.SetActive(false);
        
        yield return null;
    }

    public void RestoreFollow(){
        this.gameObject.SetActive(false);
        Invoke("InitializationFollow",0.6f);

        canFollow = false;// 将可以追踪再设置为false，追踪成功击杀玩家后，需要玩家再次去触发追踪
    }

}
