using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class View : MonoBehaviour
{
    private GameObject startInterface;

    private RectTransform title;
    private RectTransform menu;
    private RectTransform play;
    private RectTransform pause;
    private RectTransform setting;
    private GameObject backMenu;
    private GameObject backPause;
    private RectTransform save;
    private RectTransform saveHave;
    private RectTransform saveMenu;

    private RectTransform spaceTip;
    private RectTransform climbWallTip;
    private RectTransform sprintTip;
    private RectTransform glideTip;
    private RectTransform saveTip;

    private RectTransform prologueTitle;

    private PostProcessVolume postProcess;

    void Awake()
    {

        startInterface=GameObject.Find("View/Canvas/StartInterface");

        title=transform.Find("Canvas/StartInterface/Title") as RectTransform;
        menu=transform.Find("Canvas/StartInterface/Menu") as RectTransform;
        play=transform.Find("Canvas/PlayInterface") as RectTransform;
        pause=transform.Find("Canvas/PauseInterface") as RectTransform;
        setting=transform.Find("Canvas/SettingInterface") as RectTransform;
        backMenu=GameObject.Find("View/Canvas/SettingInterface/Menu/BackButtonInMenu");
        backPause=GameObject.Find("View/Canvas/SettingInterface/Menu/BackButtonInPause");
        save=transform.Find("Canvas/SaveInterface") as RectTransform;
        saveMenu=transform.Find("Canvas/SaveInterface/Menu") as RectTransform;
        saveHave=transform.Find("Canvas/SaveInterface/Menu/Archive box/Have") as RectTransform;

        spaceTip=transform.Find("Canvas/OperationTip/SpaceTip") as RectTransform;
        climbWallTip=transform.Find("Canvas/OperationTip/ClimbWallTip") as RectTransform;
        sprintTip=transform.Find("Canvas/OperationTip/SprintTip") as RectTransform;
        glideTip=transform.Find("Canvas/OperationTip/GlideTip") as RectTransform;
        saveTip=transform.Find("Canvas/OperationTip/SaveTip") as RectTransform;

        prologueTitle=transform.Find("Canvas/OpeningShow/PrologueTitle") as RectTransform;

        postProcess=GameObject.Find("View/Post Processing").GetComponent<PostProcessVolume>();
    }
    private void Start() {
        //Cursor.visible=false;// 隐藏鼠标
    }

    public void ShowMenu(){
        startInterface.SetActive(true);
        title.DOAnchorPosY(327.28f,1f); 
        menu.DOAnchorPosY(-210.32f,1f);
    }
    public void HideMenu(){
        Invoke("DisableMenu",0.25f);
        title.DOAnchorPosY(794f,1f);
        menu.DOAnchorPosY(-864f,1f);
    }
    private void DisableMenu(){
        startInterface.SetActive(false);
    }
    public void ShowPlay(){
        play.gameObject.SetActive(true);
    }
    public void HidePlay(){
        play.gameObject.SetActive(false);
    }

    public void ShowPause(){
        pause.gameObject.SetActive(true);
    }
    public void HidePause(){
        pause.gameObject.SetActive(false);
    }

    public void ShowSettingInPause(){
        setting.gameObject.SetActive(true);
        setting.gameObject.GetComponent<Image>().color=new Color(0,0,0,0.5294f);
        setting.DOAnchorPosX(0f,0.25f);
        backPause.SetActive(true);
        pause.DOAnchorPosX(-1920,0.25f);
        Invoke("HidePause",0.25f);
    }
    public void HideSettingInPause(){
        setting.DOAnchorPosX(1920f,0.25f);
        Invoke("HideSetPause",0.25f);
        pause.DOAnchorPosX(0,0.25f);
        pause.gameObject.SetActive(true);
    }

    public void ShowSettingInMenu(){
        setting.gameObject.SetActive(true);
        backMenu.SetActive(true);
        setting.DOAnchorPosX(0f,0.25f);
        title.DOAnchorPosX(-1920f,0.25f);
        menu.DOAnchorPosX(-1920f,0.25f);
        Invoke("HideTM",0.25f);
    }
    public void HideSettingInMenu(){
        setting.DOAnchorPosX(1920f,0.25f);
        Invoke("HideSetMenu",0.25f);
        title.DOAnchorPosX(0f,0.25f);
        menu.DOAnchorPosX(0f,0.25f);
        title.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
    }
    private void HideTM(){
        title.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }
    private void HideSetMenu(){
        setting.gameObject.SetActive(false);
        backMenu.SetActive(false);
    }
    private void HideSetPause(){
        setting.gameObject.SetActive(false);
        backPause.SetActive(false);
        setting.gameObject.GetComponent<Image>().color=new Color(0,0,0,0);
    }
    public void ShowSave(){
        save.gameObject.SetActive(true);
        saveMenu.DOAnchorPosY(0,0.25f);
    }
    public void HideSave(){
        save.gameObject.SetActive(false);
        saveMenu.DOAnchorPosY(1080f,0.25f);
    }
    public void ShowSaveHave(){
        saveHave.gameObject.SetActive(true);
    }
    public void HideSaveHave(){
        saveHave.gameObject.SetActive(false);
    }

    public void ShowSpaceTip(){
        spaceTip.gameObject.SetActive(true);
    }
    public void HideSpaceTip(){
        spaceTip.gameObject.SetActive(false);
    }
    public void ShowClimbWallTip(){
        climbWallTip.gameObject.SetActive(true);
    }
    public void HideClimbWallTip(){
        climbWallTip.gameObject.SetActive(false);
    }
    public void ShowSprintTip(){
        sprintTip.gameObject.SetActive(true);
    }
    public void HideSprintTip(){
        sprintTip.gameObject.SetActive(false);
    }
    public void ShowGlideTip(){
        glideTip.gameObject.SetActive(true);
    }
    public void HideGlideTip(){
        glideTip.gameObject.SetActive(false);
    }
    public void ShowSaveTip(){
        saveTip.gameObject.SetActive(true);
    }
    public void HideSaveTip(){
        saveTip.gameObject.SetActive(false);
    }

    public void ShowPrologueTitle(){
        prologueTitle.gameObject.SetActive(true);
    }
    public void HidePrologueTitleTime(){
        Invoke("HidePrologueTitle",2f);
    }
    private void HidePrologueTitle(){
        prologueTitle.gameObject.SetActive(false);
    }

    public void PostProcessToPlay(){
        postProcess.profile.GetSetting<Vignette>().intensity.value=1;
    }
    public void ExitGame(){// 退出游戏
        Invoke("Exit",0.25f);
    }
    private void Exit(){
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
