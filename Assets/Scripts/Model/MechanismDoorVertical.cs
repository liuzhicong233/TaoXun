using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismDoorVertical : MonoBehaviour
{
    public DoorMove doorMoveUp;
    public DoorMove doorMoveDown;

    private Ctrl ctrl;

    private void Start() {
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "Player")// 如果与触发点发生碰撞的是player
        {
            doorMoveUp.DoorMoveUp();
            doorMoveDown.DoorMoveDown();

            this.gameObject.GetComponent<Collider2D>().enabled = false;// 将触发点的碰撞体失活
            this.gameObject.SetActive(false);

            ctrl.audioManager.DoorTriggerAudio();
            ctrl.audioManager.MovementStoneAudio();

        }
    }
}
