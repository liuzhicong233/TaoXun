using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
    private bool isPlayState=false;
    private void Awake() {
        stateID=StateID.Play;

        AddTransition(Transition.StopButtonClick,StateID.Pause);
    }
    private void Update() {
        if(isPlayState){
            GetDownEsc();// 在Play状态时按Esc才会呼唤暂停界面
        }
    }

    public override void DoBeforeEntering()
    {   
        ctrl.view.ShowPlay();
        ctrl.cameraManager.Narrow();// 视角拉近
        ctrl.gameManager.EnableMove();// 启用移动
        isPlayState=true;
        Cursor.visible=false;
        ctrl.view.PostProcessToPlay();
        ctrl.audioManager.RainAudio();
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
    public void GetDownEsc(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            SwitchToPause();
        }
    }
}
