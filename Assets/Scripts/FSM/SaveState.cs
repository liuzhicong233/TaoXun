using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class SaveState : FSMState
{
    private void Awake() {
        stateID=StateID.Save;

        AddTransition(Transition.SaveDataButtonClick,StateID.Play);
        AddTransition(Transition.BackMenuButtonClick,StateID.Menu);
    }
    public override void DoBeforeEntering()
    {
        ctrl.view.ShowSave();
        Cursor.visible=true;
    }
    public override void DoBeforeLeaving()
    {
        ctrl.view.HideSave();
    }
    public void OnNewDataButtonClick(){// 点击新游戏按钮
        ctrl.view.HideSaveMenu();
        ctrl.view.ShowNewGame();
        ctrl.audioManager.ClickButton();
    }
    public void DetermineNewDataClick(){// 点击确定

        fsm.PerformTransition(Transition.SaveDataButtonClick);// 切换到Play状态

        ctrl.audioManager.SaveClickAudio();// 播放音效

        ctrl.playerData.DeletePlayerDatePrefs();// 删除之前存档

        ctrl.gameManager.Initialize();// 位置初始化

        ctrl.loadManager.NewGame();// 导入第一关

        ctrl.audioManager.StopRainAudio();
        ctrl.audioManager.StopWindAudio();
    }
    public void CancelNewDataClick(){// 点击取消
        ctrl.view.ShowSaveMenu();
        ctrl.view.HideNewGame();
        ctrl.audioManager.ClickButton();
    }

    public void OnContinueDataButtonClick(){// 点击继续游戏按钮

        fsm.PerformTransition(Transition.SaveDataButtonClick);// 切换到Play状态

        ctrl.audioManager.SaveClickAudio();// 播放音效

        ctrl.playerData.Load();// 导入存档
    }
    
    public void OnLevelSelectButtonClick(){// 点击关卡选择按钮
        ctrl.view.HideSaveMenu();
        ctrl.view.ShowLevelSelect();
        ctrl.audioManager.ClickButton();

        if(GlobalControl.Instance.canSelectLevel){
            ctrl.view.HideOcclusionLayer();
        }
    }

    public void OnPrologueLevelButtonClick(){
        fsm.PerformTransition(Transition.SaveDataButtonClick);// 切换到Play状态
        ctrl.loadManager.PrologueLevelLoad();

        ctrl.audioManager.ClickButton();

        ctrl.audioManager.StopRainAudio();
        ctrl.audioManager.StopWindAudio();
    }
    public void OnScene1LevelButtonClick(){
        fsm.PerformTransition(Transition.SaveDataButtonClick);// 切换到Play状态
        ctrl.loadManager.Scene1LevelLoad();

        ctrl.audioManager.ClickButton();

        ctrl.audioManager.StopRainAudio();
        ctrl.audioManager.StopWindAudio();
    }
    public void OnScene2LevelButtonClick(){
        fsm.PerformTransition(Transition.SaveDataButtonClick);// 切换到Play状态
        ctrl.loadManager.Scene2LevelLoad();

        ctrl.audioManager.ClickButton();

        ctrl.audioManager.StopRainAudio();
        ctrl.audioManager.StopWindAudio();
    }
    public void OnScene3LevelButtonClick(){
        fsm.PerformTransition(Transition.SaveDataButtonClick);// 切换到Play状态
        ctrl.loadManager.Scene3LevelLoad();

        ctrl.audioManager.ClickButton();

        ctrl.audioManager.StopRainAudio();
        ctrl.audioManager.StopWindAudio();
    }
    public void OnScene4LevelButtonClick(){
        fsm.PerformTransition(Transition.SaveDataButtonClick);// 切换到Play状态
        ctrl.loadManager.Scene4LevelLoad();

        ctrl.audioManager.ClickButton();

        ctrl.audioManager.StopRainAudio();
        ctrl.audioManager.StopWindAudio();
    }
    

    public void CancelLevelSelectClick(){
        ctrl.view.ShowSaveMenu();
        ctrl.view.HideLevelSelect();
        ctrl.audioManager.ClickButton();
    }

    public void OnBackButtonClick(){// 点击返回按钮
        fsm.PerformTransition(Transition.BackMenuButtonClick);

        ctrl.audioManager.ClickButton();
    }



    // public void OnDeleteDataButtonClick(){// 删除存档
    //     ctrl.audioManager.ClickButton();
    //     ctrl.playerData.DeletePlayerDatePrefs(); 
    // }
}
