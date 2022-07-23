using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    public AudioMixer Audio_Mixer;
    AudioSource main;
    AudioSource lv1;
    AudioSource lv2;
    AudioSource boss;
    AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
        Audio_Mixer.SetFloat("BGMVolume", -25);
        main = GameObject.Find("mainBGM").GetComponent<AudioSource>();
        lv1 = GameObject.Find("lv1BGM").GetComponent<AudioSource>();
        lv2 = GameObject.Find("lv2BGM").GetComponent<AudioSource>();
        boss = GameObject.Find("bossBGM").GetComponent<AudioSource>();
        win = GameObject.Find("winBGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBGM(string s, string i){
        print("Change BGM from " + s + " to " + i);
        if(s == i) return;
        switch(s){
            case "menu": {
                main.Stop();
                break;
            }
            case "level1": {
                lv1.Stop();
                break;
            }
            case "level2": {
                lv2.Stop();
                break;
            }
            case "win":{
                win.Stop();
                break;
            }
            default:{
                print("ERROR in ChangeBGM: Stopped BGM not found");
                break;
            }
        }
        switch(i){
            case "menu": {
                main.Play();
                break;
            }
            case "level1": {
                lv1.Play();
                break;
            }
            case "level2": {
                lv2.Play();
                break;
            }
            case "win":{
                win.Play();
                break;
            }
            default:{
                print("ERROR in ChangeBGM: Played BGM not found");
                break;
            }
        }
    }

    public void BossStage(){
        lv2.Stop();
        boss.Play();
    }

    public void BossDied(){
        boss.Pause();
        lv2.Play();
    }

    public void BackToMenu(){
    }

    public void DieInBossRoom()
    {
        if (SceneManager.GetActiveScene().name == "level2")
        {
            bool isboss = GameObject.Find("bosss").GetComponent<IsBossFight>().IsBoss;
            if (isboss)
            {
                boss.Stop();
                lv2.Play();
            }
        }
    }
}
