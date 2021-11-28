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
    public PlayerData playerData;

    private FSMSystem fsm;
    private void Awake() {
        model=GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view=GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        cameraManager=GetComponent<CameraManager>();
        gameManager=GetComponent<GameManager>();
        audioManager=GetComponent<AudioManager>();
        buttonManager=GetComponent<ButtonManager>();
        playerData=GetComponentInChildren<PlayerData>();
    }

    private void Start() {
        if(SceneManager.GetActiveScene().buildIndex==0){
            MakeFSMDefaultMenu();
        }
        if(SceneManager.GetActiveScene().buildIndex==1||SceneManager.GetActiveScene().buildIndex==2||SceneManager.GetActiveScene().buildIndex==3||SceneManager.GetActiveScene().buildIndex==4){
            MakeFSMDefaultPlay();
        }
    }

    void MakeFSMDefaultMenu(){
        fsm=new FSMSystem();
        FSMState[] states=GetComponentsInChildren<FSMState>();
        foreach(FSMState state in states){
            fsm.AddState(state,this);
        }
        MenuState s=GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(s);
    }
    void MakeFSMDefaultPlay(){
        fsm=new FSMSystem();
        FSMState[] states=GetComponentsInChildren<FSMState>();
        foreach(FSMState state in states){
            fsm.AddState(state,this);
        }
        PlayState s=GetComponentInChildren<PlayState>();
        fsm.SetCurrentState(s);
    }
}
