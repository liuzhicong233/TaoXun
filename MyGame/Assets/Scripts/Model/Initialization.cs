using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player=GameObject.Find("Ctrl/Player");
    }


}
