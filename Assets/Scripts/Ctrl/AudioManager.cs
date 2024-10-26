using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Toggle isBGM;
    public Toggle isSoundEffect;
    public AudioClip click;// 按钮点击音效
    public AudioClip saveClick;// 进入游戏音效
    public AudioClip select;// 按钮选择音效
    public AudioClip run;
    public AudioClip jump;// 跳跃音效
    public AudioClip fall;
    public AudioClip sprint;// 冲刺音效
    public AudioClip openUmbrella;// 开伞音效
    public AudioClip closeUmbrella;// 关伞音效
    public AudioClip pinball;// 弹球音效
    public AudioClip die;// 死亡音效
    public AudioClip tip;
    public AudioClip fireLight;
    public AudioClip stoneBreak;// 碎石音效
    public AudioClip fallStone;// 下落石块音效
    public AudioClip delivery;// 传送音效
    public AudioClip doorTrigger;// 触发机关门音效
    public AudioClip movementStone;// 石块移动音效
    public AudioClip targetStone;



    public AudioClip rain;// 雨声
    public AudioClip wind;// 风声

    private AudioSource soundEffect;
    private AudioSource playerBaseSound;
    private AudioSource BGM;
    private AudioSource rainEffect;
    private AudioSource[] windEffects;
    private AudioSource sceneAudio;
    private AudioSource environmentAudio;

    private bool isMute=false;
    private void Start() {
        BGM=GameObject.Find("View/BGM").GetComponent<AudioSource>();
        
        soundEffect=GetComponent<AudioSource>();
        playerBaseSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();

        rainEffect = GameObject.Find("Model/Particle Systems/Rain").GetComponentInChildren<AudioSource>();
        windEffects = GameObject.Find("Model/Particle Systems/Winds").GetComponentsInChildren<AudioSource>();

        sceneAudio=GameObject.Find("Model/Environment/SceneAudio").GetComponent<AudioSource>();
        environmentAudio = GameObject.Find("Model/Environment/EnvironmentAudio").GetComponent<AudioSource>();
    }
    
    public void IsMuteBGM(){
        if(isBGM.isOn){
            BGM.mute=false;
        }else{
            BGM.mute=true;
        }
    }
    public void IsMuteSoundEffect(){
        if(isSoundEffect.isOn){
            soundEffect.mute=false;
            playerBaseSound.mute = false;

            rainEffect.mute=false;
            
            sceneAudio.mute=false;
            environmentAudio.mute = false;

            foreach (var windEffect in windEffects)
            {
                windEffect.mute = false;
            }
        }else{
            soundEffect.mute=true;
            playerBaseSound.mute = false;

            rainEffect.mute=true;
            
            sceneAudio.mute=true;
            environmentAudio.mute = true;

            foreach (var windEffect in windEffects)
            {
                windEffect.mute = true;
            }
        }
        
    }

    public void ClickButton(){
        PlayAudio(click);
    }
    public void SelectButton(){
        PlayAudio(select);
    }
    public void RainAudio(){
        PlayRainEffect(rain);
    }
    public void StopRainAudio(){
        rainEffect.Stop();
    }
    public void WindAudio(){
        PlayWindEffect(wind);
    }
    public void StopWindAudio(){
        foreach (var windEffect in windEffects)
        {
            windEffect.Stop();
        }
    }
    public void RunAudio(){
        playerBaseSound.clip = run;
        playerBaseSound.Play();
    }
    public void StopRunAudio(){
        playerBaseSound.Stop();
    }


    public void JumpAudio(){
        playerBaseSound.clip = jump;
        playerBaseSound.Play();
    }
    public void FallAudio(){
        PlayAudio(fall);
    }
    public void SprintAudio(){
        PlayAudio(sprint);
    }
    public void OpenUmAudio(){
        PlayAudio(openUmbrella);
    }
    public void CloseUmAudio(){
        PlayAudio(closeUmbrella);
    }
    public void DieAudio(){
        PlayAudio(die);
    }
    public void SaveClickAudio(){
        PlayAudio(saveClick);
    }
    public void TipAudio(){
        PlayAudio(tip);
    }
    public void FireLightAudio(){
        sceneAudio.clip=fireLight;
        sceneAudio.Play();
    }
    public void StoneBreakAudio(){
        sceneAudio.clip=stoneBreak;
        sceneAudio.Play();
    }
    public void PinballAudio(){// 播放弹球的音效
        sceneAudio.clip = pinball;
        sceneAudio.Play();
    }
    public void FallStoneAudio(){
        sceneAudio.clip = fallStone;
        sceneAudio.Play();
    }
    public void DeliveryAudio(){
        sceneAudio.clip = delivery;
        sceneAudio.Play();
    }
    public void DoorTriggerAudio(){
        sceneAudio.clip = doorTrigger;
        sceneAudio.Play();
    }
    public void MovementStoneAudio(){
        environmentAudio.clip = movementStone;
        environmentAudio.Play();
    }
    public void TargetStoneAudio(){
        sceneAudio.clip = targetStone;
        sceneAudio.Play();
    }


    private void PlayAudio(AudioClip clip){
        if(isMute) return;
        soundEffect.clip=clip;
        soundEffect.Play();
    }
    private void PlayBGM(AudioClip clip){
        if(isMute) return;
        BGM.clip=clip;
        BGM.Play();
    }
    private void PlayRainEffect(AudioClip clip){
        if(isMute) return;
        rainEffect.clip=clip;
        if(rainEffect.isActiveAndEnabled){
            rainEffect.Play();
        }
    }
    private void PlayWindEffect(AudioClip clip){
        if(isMute) return;
        foreach (var windEffect in windEffects)
        {
            windEffect.clip=clip;
            if(windEffect.isActiveAndEnabled){
                windEffect.Play();
        }
        }
        
    }
}
