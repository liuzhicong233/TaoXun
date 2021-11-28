using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : FSMState
{
    private void Awake() {
        stateID=StateID.Save;

        AddTransition(Transition.SaveDataButtonClick,StateID.Play);
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
    public void OnNewDataButtonClick(){
        fsm.PerformTransition(Transition.SaveDataButtonClick);
        ctrl.audioManager.SaveClickAudio();
        ctrl.playerData.DeletePlayerDatePrefs();
        ctrl.gameManager.Initialize();
    }
    public void OnContinueDataButtonClick(){
        fsm.PerformTransition(Transition.SaveDataButtonClick);
        ctrl.audioManager.SaveClickAudio();
        ctrl.playerData.Load();
    }
    public void OnDeleteDataButtonClick(){
        ctrl.audioManager.ClickButton();
        ctrl.playerData.DeletePlayerDatePrefs();
    }
}
