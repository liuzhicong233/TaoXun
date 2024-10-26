using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingState : FSMState
{
    public void OnBGMToggleClick(){
        ctrl.audioManager.ClickButton();
        ctrl.audioManager.IsMuteBGM();
    }
    public void OnSoundEffectToggleClick(){
        ctrl.audioManager.ClickButton();
        ctrl.audioManager.IsMuteSoundEffect();
    }
}
