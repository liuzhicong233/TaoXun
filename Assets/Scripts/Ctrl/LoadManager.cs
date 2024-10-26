using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public Text text;


    private Ctrl ctrl;
    

    private void Start() {
        ctrl=GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel());

    }

    public void NewGame(){
        StartCoroutine(NewLevel());
    }

    public void RestartTheLevel(){
        StartCoroutine(RestartLevel());
    }

    public void PrologueLevelLoad(){
        StartCoroutine(PrologueLevel());
    }
    public void Scene1LevelLoad(){
        StartCoroutine(Scene1Level());
    }
    public void Scene2LevelLoad(){
        StartCoroutine(Scene2Level());
    }
    public void Scene3LevelLoad(){
        StartCoroutine(Scene3Level());
    }
    public void Scene4LevelLoad(){
        StartCoroutine(Scene4Level());
    }


    IEnumerator LoadLevel(){

        loadScreen.SetActive(true);

        AsyncOperation operation=SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);

        operation.allowSceneActivation=false;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }

            yield return null;
        }
    }
    IEnumerator RestartLevel(){

        loadScreen.SetActive(true);

        yield return new WaitForSeconds(0.2f);// 等音效放完


        AsyncOperation operation=SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);


        operation.allowSceneActivation=false;

        Time.timeScale = 1f;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }

            yield return null;
        }
    }

    IEnumerator NewLevel(){

        loadScreen.SetActive(true);

        yield return new WaitForSeconds(0.7f);// 等音效放完

        AsyncOperation operation=SceneManager.LoadSceneAsync(0);

        operation.allowSceneActivation=false;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }


            yield return null;
        }
    }

    IEnumerator PrologueLevel(){

        loadScreen.SetActive(true);

        yield return new WaitForSeconds(0.2f);// 等音效放完

        AsyncOperation operation=SceneManager.LoadSceneAsync(0);

        operation.allowSceneActivation=false;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }

            yield return null;
        }
    }
    IEnumerator Scene1Level(){

        loadScreen.SetActive(true);

        yield return new WaitForSeconds(0.2f);// 等音效放完

        AsyncOperation operation=SceneManager.LoadSceneAsync(1);

        operation.allowSceneActivation=false;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }

            yield return null;
        }
    }
    IEnumerator Scene2Level(){

        loadScreen.SetActive(true);

        yield return new WaitForSeconds(0.2f);// 等音效放完

        AsyncOperation operation=SceneManager.LoadSceneAsync(2);

        operation.allowSceneActivation=false;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }

            yield return null;
        }
    }
    IEnumerator Scene3Level(){

        loadScreen.SetActive(true);

        yield return new WaitForSeconds(0.2f);// 等音效放完

        AsyncOperation operation=SceneManager.LoadSceneAsync(3);

        operation.allowSceneActivation=false;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }

            yield return null;
        }
    }
    IEnumerator Scene4Level(){

        loadScreen.SetActive(true);

        yield return new WaitForSeconds(0.2f);// 等音效放完

        AsyncOperation operation=SceneManager.LoadSceneAsync(4);

        operation.allowSceneActivation=false;

        while(!operation.isDone){
            slider.value=operation.progress;

            text.text=operation.progress*100+"%";

            if(operation.progress>=0.9f){
                slider.value=1;

                operation.allowSceneActivation=true;
            }

            yield return null;
        }
    }

    
}
