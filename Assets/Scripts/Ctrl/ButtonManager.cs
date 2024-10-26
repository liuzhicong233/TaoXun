using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Playables;


public class ButtonManager : MonoBehaviour
{
    
    public PlayableDirector timeline_comeback;

    [HideInInspector]
    public Ctrl ctrl;

    private void Start() {
        ctrl = GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }


    public void ComeBackButtonClick(){// 当玩家点击拿走高岭土按钮
        timeline_comeback.Play();// 执行timeline_comeback的动画

        Cursor.visible = false;

        ctrl.audioManager.ClickButton();

        StartCoroutine(FinishGame());// 然后过20s执行之后的操作
    }
    
    public void NoButtonClick(){// 当玩家点击不拿高岭土按钮

        Cursor.visible = false;

        ctrl.audioManager.ClickButton();

        FinishAndShowPT();
    }

    IEnumerator FinishGame(){
        yield return new WaitForSeconds(20f);

        timeline_comeback.gameObject.SetActive(false);

        FinishAndShowPT();
    }

    private void FinishAndShowPT(){

        ctrl.playState.FSM.PerformTransition(Transition.FinishButtonClick);

        ctrl.view.ShowProductionTeam();// 显示制作组名单
        ctrl.menuState.canEsc = true;

        ctrl.view.HideContinueGameButton();// 隐藏继续游戏按钮

        ctrl.playerData.InactivationPlayer();// 失活主角
    }

}
