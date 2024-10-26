using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{

    [HideInInspector]
    public bool canEsc;
    private void Awake() {
        stateID=StateID.Menu;

        AddTransition(Transition.StartButtonClick,StateID.Save);
    }

    private void Update() {
        if(canEsc){
            GetDownEsc();
        }
    }

    // private void OnEnable() {
    //     EventHandle.ComeBackEvent += OnComeBackEvent;
    // }
    // private void OnDisable() {
    //     EventHandle.ComeBackEvent += OnComeBackEvent;
    // }

    // private void OnComeBackEvent()// comeback结束事件
    // {
    //     ctrl.view.ShowProductionTeam();// 显示制作组名单
    //     canEsc = true;

    //     ctrl.view.HideContinueGameButton();// 隐藏继续游戏按钮

    //     ctrl.playerData.InactivationPlayer();// 失活主角
    // }

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
    public void OnProductionTeamButtonClick(){
        ctrl.view.ShowProductionTeam();
        ctrl.audioManager.ClickButton();
        canEsc = true;
    }
    private void GetDownEsc(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            ctrl.view.HideProducitonTeam();
            
            canEsc = false;

            ctrl.audioManager.ClickButton();

        }
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
