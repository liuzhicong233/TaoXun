using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    
    /*private void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }*/

    private Ctrl ctrl;

    private void Start() {
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ctrl.loadManager.LoadNextLevel();
    }
}