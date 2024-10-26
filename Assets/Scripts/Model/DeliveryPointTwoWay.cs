using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPointTwoWay : MonoBehaviour
{
    public GameObject target;//传送后的目的物体

    private Ctrl ctrl;

    private void Start() {
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Vector3 tempVec =(other.gameObject.transform.position - this.transform.position) * 1.2f;

        if (other.gameObject.name== "Player")//被传送的物体
        {
            other.gameObject.transform.position = target.transform.position - tempVec;

            ctrl.audioManager.DeliveryAudio();

        }
    }
}
