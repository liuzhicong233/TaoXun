using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{
    private void Awake() {
        stateID=StateID.Menu;

        AddTransition(Transition.StartButtonClick,StateID.Save);
    }
    public override void DoBeforeEntering()// 进入开始状态时
    {
        ctrl.view.ShowMenu();
        ctrl.cameraManager.Enlarge();
        ctrl.gameManager.DisableMove();// 禁用移动
        Cursor.visible=true;
    }
    public override void DoBeforeLeaving()
    {
        ctrl.view.HideMenu();
    }
    public void OnStartButtonClick(){// 点击开始游戏
        fsm.PerformTransition(Transition.StartButtonClick);
        ctrl.audioManager.ClickButton();
    }
    public void OnSettingButtonClick(){// 点击选项
        ctrl.view.ShowSettingInMenu();
        ctrl.audioManager.ClickButton();
    }
    public void OnBackButtonClick(){
       
        ctrl.view.HideSettingInMenu();
        ctrl.audioManager.ClickButton();
    }
    public void OnExitGameButtonClick(){// 点击退出游戏
        ctrl.view.ExitGame();
        ctrl.audioManager.ClickButton();
    }
}
