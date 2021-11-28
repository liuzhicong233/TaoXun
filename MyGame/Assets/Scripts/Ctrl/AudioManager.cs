using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Toggle isBGM;
    public Toggle isSoundEffect;
    public AudioClip click;
    public AudioClip saveClick;
    public AudioClip select;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip fall;
    public AudioClip sprint;
    public AudioClip openUmbrella;
    public AudioClip closeUmbrella;
    public AudioClip die;
    public AudioClip tip;

    //public AudioClip menuBGM;
    //public AudioClip gameBGM;
    public AudioClip rain;

    private AudioSource soundEffect;
    private AudioSource BGM;
    private AudioSource rainEffect;

    private bool isMute=false;
    private void Awake() {
        BGM=GameObject.Find("View/BGM").GetComponent<AudioSource>();
        soundEffect=GetComponent<AudioSource>();
        rainEffect=GameObject.Find("Model/Particle Systems/Rain").GetComponentInChildren<AudioSource>();
    }
    private void Update() {
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
            rainEffect.mute=false;
        }else{
            soundEffect.mute=true;
            rainEffect.mute=true;
        }
        
    }
    /*public void MenuBGM(){
        PlayBGM(menuBGM);
    }
    public void GameBGM(){
        PlayBGM(gameBGM);
    }*/
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
    public void RunAudio(){
        if(isMute) return;
        soundEffect.clip=run;
        soundEffect.Play();
        soundEffect.loop=true;
        soundEffect.pitch=1.2f;
    }
    public void StopRunAudio(){
        if(isMute) return;
        soundEffect.loop=false;
        soundEffect.pitch=1.0f;
    }
    public void JumpAudio(){
        PlayAudio(jump);
    }
    public void FallAudio(){
        PlayAudio(fall);

    }
    public void SprintAudio(){
        PlayAudio(sprint);
        soundEffect.loop=false;
        soundEffect.pitch=1.0f;
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
    public void StopTipAudio(){
        if(soundEffect.clip==tip){
            soundEffect.Stop();
        }
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
        rainEffect.clip=rain;
        if(rainEffect.isActiveAndEnabled){
            rainEffect.Play();

        }
    }
}
