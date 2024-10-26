using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class View : MonoBehaviour
{

    // UI
    private GameObject startInterface;
    private RectTransform title;
    private RectTransform menu;

    private RectTransform play;

    private RectTransform pause;
    private RectTransform titlePause;
    private RectTransform menuPause;

    private RectTransform restart;

    private RectTransform setting;
    private GameObject backMenu;
    private GameObject backPause;

    private RectTransform save;
    private RectTransform saveMenu;
    private RectTransform continueGameButton;
    private RectTransform newGame;
    private RectTransform levelSelect;
    private RectTransform occlusionLayer;

    private RectTransform productionTeam;


    // Tip
    private RectTransform spaceTip;
    private RectTransform climbWallTip;
    private RectTransform sprintTip;
    private RectTransform glideTip;
    private RectTransform saveTip;
    private RectTransform jumpTwiceTip;


    void Awake()
    {

        startInterface=GameObject.Find("View/Canvas/StartInterface");

        title=transform.Find("Canvas/StartInterface/Title") as RectTransform;
        menu=transform.Find("Canvas/StartInterface/Menu") as RectTransform;
        play=transform.Find("Canvas/PlayInterface") as RectTransform;

        pause=transform.Find("Canvas/PauseInterface") as RectTransform;
        titlePause = transform.Find("Canvas/PauseInterface/Title") as RectTransform;
        menuPause = transform.Find("Canvas/PauseInterface/Menu") as RectTransform;
        restart = transform.Find("Canvas/PauseInterface/Restart") as RectTransform;


        setting=transform.Find("Canvas/SettingInterface") as RectTransform;
        backMenu=GameObject.Find("View/Canvas/SettingInterface/Menu/BackButtonInMenu");
        backPause=GameObject.Find("View/Canvas/SettingInterface/Menu/BackButtonInPause");

        save=transform.Find("Canvas/SaveInterface") as RectTransform;
        saveMenu=transform.Find("Canvas/SaveInterface/Menu") as RectTransform;
        continueGameButton = transform.Find("Canvas/SaveInterface/Menu/ContinueGameButton") as RectTransform;

        newGame = transform.Find("Canvas/SaveInterface/NewGame") as RectTransform;
        levelSelect = transform.Find("Canvas/SaveInterface/LevelSelect") as RectTransform;
        occlusionLayer = transform.Find("Canvas/SaveInterface/LevelSelect/OcclusionLayer") as RectTransform;

        productionTeam = transform.Find("Canvas/StartInterface/ProductionTeam") as RectTransform;


        spaceTip=transform.Find("GameCanvas/OperationTip/SpaceTip") as RectTransform;
        climbWallTip=transform.Find("GameCanvas/OperationTip/ClimbWallTip") as RectTransform;
        sprintTip=transform.Find("GameCanvas/OperationTip/SprintTip") as RectTransform;
        glideTip=transform.Find("GameCanvas/OperationTip/GlideTip") as RectTransform;
        saveTip=transform.Find("GameCanvas/OperationTip/SaveTip") as RectTransform;
        jumpTwiceTip=transform.Find("GameCanvas/OperationTip/JumpTwiceTip") as RectTransform;

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

    public void ShowPauseTM(){
        // Invoke("TruePauseTM",0f);

        Tweener tweener1 = titlePause.DOAnchorPosX(0f,0.25f);
        tweener1.SetUpdate(true);
        Tweener tweener2 = menuPause.DOAnchorPosX(0f,0.25f);
        tweener2.SetUpdate(true);

    }
    public void HidePauseTM(){
        // Invoke("FalsePauseTM",0.25f);

        Tweener tweener1 = titlePause.DOAnchorPosX(-1920f,0.25f);
        tweener1.SetUpdate(true);
        Tweener tweener2 = menuPause.DOAnchorPosX(-1920f,0.25f);
        tweener2.SetUpdate(true);
    }
    private void TruePauseTM(){
        titlePause.gameObject.SetActive(true);
        menuPause.gameObject.SetActive(true);
    }
    private void FalsePauseTM(){
        titlePause.gameObject.SetActive(false);
        menuPause.gameObject.SetActive(false);
    }

    public void ShowRestart(){
        TrueRestart();

        Tweener tweener = restart.DOAnchorPosX(0,0.25f);
        tweener.SetUpdate(true);
    }
    public void HideRestart(){
        FalseRestart();// 还未解决时间暂停如何等待0.25s的办法，所以直接把重新开始界面失活

        Tweener tweener = restart.DOAnchorPosX(1920f,0.25f);
        tweener.SetUpdate(true);
    }
    private void TrueRestart(){
        restart.gameObject.SetActive(true);
    }
    private void FalseRestart(){
        restart.gameObject.SetActive(false);
    }


    public void ShowSettingInPause(){
        setting.gameObject.SetActive(true);
        setting.gameObject.GetComponent<Image>().color=new Color(0,0,0,0.5294f);

        Tweener tweener1 = setting.DOAnchorPosX(0f,0.25f);
        tweener1.SetUpdate(true);// 忽略游戏时间的暂停，不然动画没法播放
        Tweener tweener2 = pause.DOAnchorPosX(-1920,0.25f);
        tweener2.SetUpdate(true);

        backPause.SetActive(true);

        Invoke("HidePause",0.25f);
    }
    public void HideSettingInPause(){
        Tweener tweener1 = setting.DOAnchorPosX(1920f,0.25f);
        tweener1.SetUpdate(true);
        Tweener tweener2 = pause.DOAnchorPosX(0,0.25f);
        tweener2.SetUpdate(true);

        Invoke("HideSetPause",0.25f);
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
        saveMenu.DOAnchorPosY(0f,0.25f);
    }
    public void HideSave(){
        save.gameObject.SetActive(false);
        saveMenu.DOAnchorPosY(1080f,0.25f);
    }
    public void ShowContinueGameButton(){
        continueGameButton.gameObject.SetActive(true);
    }
    public void HideContinueGameButton(){
        continueGameButton.gameObject.SetActive(false);
    }

    public void ShowNewGame(){
        Invoke("TrueNewGame",0f);

        newGame.DOAnchorPosX(0f,0.25f);
    }
    public void HideNewGame(){
        Invoke("FalseNewGame",0.25f);

        newGame.DOAnchorPosX(1920f,0.25f);
    }
    public void ShowLevelSelect(){
        Invoke("TrueLevelSelect",0f);

        levelSelect.DOAnchorPosX(0f,0.25f);
    }
    public void HideLevelSelect(){
        Invoke("FalseLevelSelect",0.25f);

        levelSelect.DOAnchorPosX(1920f,0.25f);
    }
    public void HideOcclusionLayer(){
        occlusionLayer.gameObject.SetActive(false);
    }

    public void ShowSaveMenu(){
        Invoke("TrueSaveMenu",0f);

        saveMenu.DOAnchorPosX(0f,0.25f);
    }
    public void HideSaveMenu(){
        Invoke("TrueSaveMenu",0.25f);

        saveMenu.DOAnchorPosX(-1920f,0.25f);
    }

    private void TrueNewGame(){
        newGame.gameObject.SetActive(true);
    }
    private void FalseNewGame(){
        newGame.gameObject.SetActive(false);
    }
    private void TrueLevelSelect(){
        levelSelect.gameObject.SetActive(true);
    }
    private void FalseLevelSelect(){
        levelSelect.gameObject.SetActive(false);
    }
    private void TrueSaveMenu(){
        saveMenu.gameObject.SetActive(true);
    }
    private void FalseSaveMenu(){
        saveMenu.gameObject.SetActive(false);
    }

    public void ShowProductionTeam(){
        productionTeam.gameObject.SetActive(true);

        menu.gameObject.SetActive(false);
        title.gameObject.SetActive(false);

        title.DOAnchorPosY(794f,1f);
        menu.DOAnchorPosY(-864f,1f);
    }
    public void HideProducitonTeam(){
        productionTeam.gameObject.SetActive(false);


        menu.gameObject.SetActive(true);
        title.gameObject.SetActive(true);

        title.DOAnchorPosY(327.28f,1f); 
        menu.DOAnchorPosY(-210.32f,1f);
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
    public void ShowJumpTwiceTip(){
        jumpTwiceTip.gameObject.SetActive(true);
    }
    public void HideJumpTwiceTip(){
        jumpTwiceTip.gameObject.SetActive(false);
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
