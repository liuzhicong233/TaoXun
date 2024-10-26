using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl
{
    private GlobalControl(){

    }
    private static GlobalControl _instance;
    public static GlobalControl Instance{
        get{
            if(_instance == null){
                _instance = new GlobalControl();
            }
            return _instance;
        }
    }

   public bool canSelectLevel{get;set;}

//    public bool canFSM_Menu = true;


    // private static GlobalData _instance;
    // public static GlobalData Instance {get{return _instance;}}
    // private void Awake(){

    //     if(_instance!=null){
    //         Destroy(this.gameObject);
    //         return;

    //     }else{
    //         _instance=this;
    //     }
            
    // }

    // public void DoOcclusionLayer(){
    //     DontDestroyOnLoad(this.gameObject);
    // }
}
