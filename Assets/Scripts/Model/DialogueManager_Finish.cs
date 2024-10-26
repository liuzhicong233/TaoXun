using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager_Finish : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("头像")]
    public Sprite face1,face2;

    private bool textFinished;

    [HideInInspector]
    public Ctrl ctrl;
    List<string> textList=new List<string>();

    [Header("Others")]
    public GameObject lastChoice;

    private void Awake() {
        GetTextFormFile(textFile);
    }
    private void Start() {
        ctrl = GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }
    private void OnEnable() {
        textFinished=true;
        StartCoroutine(SetTextUI());

    }


    private void Update() {

        if(Input.GetKeyDown(KeyCode.R) && index == textList.Count){

            gameObject.SetActive(false);
            index = 0;

            // ctrl.gameManager.EnableMove();// 启用移动
            // ctrl.playState.canPause = true;// 对话结束时可以暂停

            ctrl.cameraManager.Narrow();// 恢复视角

            lastChoice.SetActive(true);

            Cursor.visible = true;

            
            return;
        }
        if(Input.GetKeyDown(KeyCode.R)&&textFinished==true){
            StartCoroutine(SetTextUI());
        }
    }
    void GetTextFormFile(TextAsset file){
        textList.Clear();
        index=0;

        var lineData=file.text.Split('\n');
        foreach(var line in lineData){
            textList.Add(line);
        }

    }

    IEnumerator SetTextUI()
    {
        textFinished=false;
        textLabel.text=null;

        switch(textList[index].Trim().ToString())
        {
            case "A":
                faceImage.sprite=face2;
                index++;
                break;
            case "B":
                faceImage.sprite=face1;
                index++;
                break;
        }

        for(int i =0;i<textList[index].Length;i++){
            textLabel.text+=textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished=true;
        index++;
    }
}
