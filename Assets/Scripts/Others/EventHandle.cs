using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventHandle
{
    public static event Action PlayerDieEvent;
    public static void CallPlayerDieEvent(){
        PlayerDieEvent?.Invoke();
    }

    public static event Action GameFinishEvent;
    public static void CallGameFinishEvent(){
        GameFinishEvent?.Invoke();
    }

    // public static event Action ComeBackEvent;
    // public static void CallComeBackEvent(){
    //     ComeBackEvent?.Invoke();
    // }
}
