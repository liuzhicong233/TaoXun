using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initialization : MonoBehaviour
{

    public GameObject[] stones;
    public Sprite rock;

    public GameObject[] targetStones;




    private void Start() {
        stones = GameObject.FindGameObjectsWithTag("Stone");

        targetStones = GameObject.FindGameObjectsWithTag("TargetStone");


    }
    public void RecoveryStone(){
        StartCoroutine(Stone());
    }
    IEnumerator Stone(){
        yield return new WaitForSeconds(0.5f);
        foreach(var stone in stones){
            stone.SetActive(true);
            stone.GetComponent<SpriteRenderer>().sprite=rock;
        }
    }

    public void RecoveryTargetStone(){
        StartCoroutine(TargetStone());
    }
    IEnumerator TargetStone(){
        yield return new WaitForSeconds(0.5f);
        foreach (var target in targetStones)
        {
            target.GetComponent<TargetStone>().InitializationTarget();
        }
    }


}
