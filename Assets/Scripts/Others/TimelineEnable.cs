using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System;

public class TimelineEnable : MonoBehaviour
{
    private PlayableDirector timeline;

    private GameObject gameFinish;


    void Start()
    {
        timeline = GameObject.Find("Model/Timelines/Timeline").GetComponent<PlayableDirector>();

        gameFinish = GameObject.Find("Model/InteractionPoints/GameFinish");
    }

    private void OnEnable() {
        EventHandle.GameFinishEvent += OnGameFinishEvent;
    }

    private void OnDisable() {
        EventHandle.GameFinishEvent -= OnGameFinishEvent;
        
    }

    private void OnGameFinishEvent()
    {
        timeline.Play();
        
        gameFinish.GetComponent<Collider2D>().enabled = false;
    }
}
