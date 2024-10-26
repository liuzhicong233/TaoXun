using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSetting : MonoBehaviour
{
    [HideInInspector]
    public Ctrl ctrl;

    private void Start() {
        ctrl = GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            // 这个是个全局的数据，当我们碰到finish时将其设置为true，那么之后无论跳到哪个场景它一直是true。
            GlobalControl.Instance.canSelectLevel = true;
        }
    }
}
