using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ctrl : MonoBehaviour
{
    [HideInInspector]
    public Model model;
    
    [HideInInspector]
    public View view;

    [HideInInspector]
    public CameraManager cameraManager;
    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public AudioManager audioManager;
    [HideInInspector]
    public ButtonManager buttonManager;
    [HideInInspector]
    public LoadManager loadManager;

    [HideInInspector]
    public Initialization initialization;

    [HideInInspector]
    public PlayerData playerData;

    [HideInInspector]
    public GameSaveManager gameSaveManager;

    [HideInInspector]
    public PlayState playState;

    [HideInInspector]
    public MenuState menuState;

    [HideInInspector]
    public SaveState saveState;

    private FSMSystem fsm;

    private void Awake() {
        model=GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view=GameObject.FindGameObjectWithTag("View").GetComponent<View>();

        cameraManager=GetComponent<CameraManager>();
        gameManager=GetComponent<GameManager>();
        audioManager=GetComponent<AudioManager>();
        buttonManager=GetComponent<ButtonManager>();
        loadManager=GetComponent<LoadManager>();
        gameSaveManager=GetComponent<GameSaveManager>();

        initialization=GetComponent<Initialization>();
        playerData=GetComponentInChildren<PlayerData>();

        playState = GetComponentInChildren<PlayState>();
        menuState = GetComponentInChildren<MenuState>();
        saveState = GetComponentInChildren<SaveState>();
        
    }

    private void Start() {
        if(SceneManager.GetActiveScene().buildIndex==0){

            // if(GlobalControl.Instance.canFSM_Menu){
            //     MakeFSMDefaultMenu();
            // }else{
            //     MakeFSMDefaultPlay();
            // }

            MakeFSMDefaultPlay();
        }
        if(SceneManager.GetActiveScene().buildIndex==1||SceneManager.GetActiveScene().buildIndex==2||SceneManager.GetActiveScene().buildIndex==3||SceneManager.GetActiveScene().buildIndex==4){
            
            // if(GlobalControl.Instance.canFSM_Menu){
            //     MakeFSMDefaultMenu();
            // }else{
            //     MakeFSMDefaultPlay();
            // }

            MakeFSMDefaultPlay();

        }
    }

    public void MakeFSMDefaultMenu(){
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach(FSMState state in states){
            fsm.AddState(state,this);
        }
        MenuState s = GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(s);
    }
    public void MakeFSMDefaultPlay(){
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach(FSMState state in states){
            fsm.AddState(state,this);
        }
        PlayState s = GetComponentInChildren<PlayState>();
        fsm.SetCurrentState(s);
    }
}
