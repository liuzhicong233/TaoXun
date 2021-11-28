using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : FSMState
{
    private void Awake() {
        stateID=StateID.Pause;
        
        AddTransition(Transition.BackGameButtonClick,StateID.Play);
        AddTransition(Transition.BackMenuButtonClick,StateID.Menu);
    }
    public override void DoBeforeEntering()
    {
        ctrl.view.ShowPause();
        Cursor.visible=true;
        ctrl.gameManager.PauseTime();
        ctrl.gameManager.DisableMove();
        ctrl.audioManager.StopRainAudio();
    }
    public override void DoBeforeLeaving()
    {
        ctrl.view.HidePause();
        ctrl.gameManager.ContinueTime();
    }
    
    public void OnBackGameButtonClick(){
        fsm.PerformTransition(Transition.BackGameButtonClick);
        ctrl.audioManager.ClickButton();
    }
    public void OnSettingButtonClick(){// 点击选项
        ctrl.view.ShowSettingInPause();
        ctrl.audioManager.ClickButton();
        ctrl.gameManager.ContinueTime();
    }
    public void OnBackButtonClick(){
        
        ctrl.view.HideSettingInPause();
        ctrl.audioManager.ClickButton();
    }
    public void OnBackMenuButtonClick(){// 点击返回菜单，回到开始状态
        fsm.PerformTransition(Transition.BackMenuButtonClick);
        ctrl.audioManager.ClickButton();
    }
}
