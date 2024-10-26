using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Ctrl ctrl;

    public float force;

    public Sprite sprite;
    

    private void Start() {

        _rigidbody=GameObject.Find("Ctrl/Player").GetComponent<Rigidbody2D>();

        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            
            gameObject.GetComponent<Animator>().enabled = true;
            Invoke("InactivationPinball",0.33f);

            
            _rigidbody.velocity=new Vector2(_rigidbody.velocity.x,force);

            ctrl.audioManager.PinballAudio();

            Invoke("RecoveryPinball",2f);

            
            // player2D.isJump=true;
            // player2D.jumpData=player2D.jumpCount;
        }
    }
    
    private void RecoveryPinball(){
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.GetComponent<Animator>().enabled = false;
    }

    private void InactivationPinball(){
        gameObject.SetActive(false);
    }
}
