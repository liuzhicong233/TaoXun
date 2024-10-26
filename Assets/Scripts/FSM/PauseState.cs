using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseState : FSMState
{

    private void Awake() {
        stateID = StateID.Pause;
        
        AddTransition(Transition.BackGameButtonClick,StateID.Play);
        AddTransition(Transition.BackMenuButtonClick,StateID.Menu);
    }

    public override void DoBeforeEntering()// 进入状态时
    {
        ctrl.view.ShowPause();
        Cursor.visible=true;
        ctrl.gameManager.PauseTime();// 暂停时间
        ctrl.gameManager.DisableMove();

        ctrl.audioManager.StopRainAudio();
        ctrl.audioManager.StopWindAudio();

    }
    public override void DoBeforeLeaving()// 退出状态时
    {
        ctrl.view.HidePause();
        ctrl.gameManager.ContinueTime();
    }
    
    public void OnBackGameButtonClick(){// 点击返回游戏按钮
        fsm.PerformTransition(Transition.BackGameButtonClick);
        ctrl.audioManager.ClickButton();
    }
    public void OnSettingButtonClick(){// 点击选项
        ctrl.view.ShowSettingInPause();
        ctrl.audioManager.ClickButton();
    }
    public void OnBackButtonClick(){// setting中的返回
        
        ctrl.view.HideSettingInPause();
        ctrl.audioManager.ClickButton();
    }

    public void OnRestartButtonClick(){// 点击重新开始本章节
        ctrl.view.ShowRestart();
        ctrl.view.HidePauseTM();
        ctrl.audioManager.ClickButton();
    }
    public void OnDetermineRestartClick(){// 确定重新开始本章节
        ctrl.loadManager.RestartTheLevel();

        ctrl.gameManager.ContinueTime();// 继续时间

        ctrl.audioManager.ClickButton();
    }
    public void OnCancelClick(){// 取消
        ctrl.view.HideRestart();
        ctrl.view.ShowPauseTM();
        ctrl.audioManager.ClickButton();
    }

    public void OnBackMenuButtonClick(){// 点击返回菜单，回到开始状态
        fsm.PerformTransition(Transition.BackMenuButtonClick);
        ctrl.playerData.Save();
        ctrl.playerData.InactivationPlayer();// 失活player

        
        ctrl.audioManager.ClickButton();
    }

}
