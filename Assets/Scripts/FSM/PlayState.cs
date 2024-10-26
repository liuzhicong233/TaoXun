using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
    [HideInInspector]
    public bool isPlayState=false;
    
    [HideInInspector]
    public bool canPause = true;
    private void Awake() {
        stateID=StateID.Play;

        AddTransition(Transition.StopButtonClick,StateID.Pause);
        AddTransition(Transition.FinishButtonClick,StateID.Menu);
    }
    private void Update() {
        if(isPlayState && canPause){
            GetDownEsc();// 在Play状态同时可以暂停按Esc才会呼唤暂停界面
        }
    }

    // private void OnEnable() {
    //     EventHandle.ComeBackEvent += OnComeBackEvent;
    // }
    // private void OnDisable() {
    //     EventHandle.ComeBackEvent += OnComeBackEvent;
    // }

    // private void OnComeBackEvent()
    // {
    //     fsm.PerformTransition(Transition.FinishButtonClick);// 切换到menu状态

    // }


    public override void DoBeforeEntering()
    {   
        ctrl.view.ShowPlay();
        ctrl.cameraManager.Narrow();// 视角拉近
        ctrl.gameManager.EnableMove();// 启用移动
        isPlayState=true;
        Cursor.visible=false;


        ctrl.audioManager?.RainAudio();
        ctrl.audioManager?.WindAudio();
    }
    public override void DoBeforeLeaving()
    {
        ctrl.view.HidePlay();
        isPlayState=false;
    }
    public void SwitchToPause(){// 点击暂停，切换到Pause状态
        fsm.PerformTransition(Transition.StopButtonClick);
        ctrl.audioManager.ClickButton();
    }
    private void GetDownEsc(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            SwitchToPause();
        }
    }
}
