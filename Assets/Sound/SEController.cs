using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SEController : MonoBehaviour
{
    AudioSource balance;
    AudioSource droptrap;
    AudioSource scissors;
    AudioSource trigger;
    AudioSource dooropen;
    AudioSource dash;
    AudioSource jump;
    AudioSource recall;
    AudioSource playerdie;
    AudioSource CDboom;
    AudioSource bugatk;
    AudioSource CDcountdown;
    AudioSource slurp;
    AudioSource enemydie;
    AudioSource getstar;
    AudioSource checkpoint;
    AudioSource buzz;
    AudioSource bomb;
    AudioSource enemyshoot;
    AudioSource rock;
    AudioSource teleport;
    AudioSource bossmove;
    AudioSource Do;
    AudioSource Mi;
    AudioSource Sol;
    
    // Start is called before the first frame update
    void Start()
    {
        balance = GameObject.Find("balanceSE").GetComponent<AudioSource>();
        droptrap = GameObject.Find("droptrapSE").GetComponent<AudioSource>();
        scissors = GameObject.Find("scissorsSE").GetComponent<AudioSource>();
        trigger = GameObject.Find("triggerSE").GetComponent<AudioSource>();
        dooropen = GameObject.Find("dooropenSE").GetComponent<AudioSource>();
        dash = GameObject.Find("dashSE").GetComponent<AudioSource>();
        jump = GameObject.Find("jumpSE").GetComponent<AudioSource>();
        recall = GameObject.Find("recallSE").GetComponent<AudioSource>();
        playerdie = GameObject.Find("playerdieSE").GetComponent<AudioSource>();
        CDboom = GameObject.Find("CDboomSE").GetComponent<AudioSource>();
        bugatk = GameObject.Find("bugatkSE").GetComponent<AudioSource>();
        CDcountdown = GameObject.Find("CDcountdownSE").GetComponent<AudioSource>();
        slurp = GameObject.Find("slurpSE").GetComponent<AudioSource>();
        enemydie = GameObject.Find("enemydieSE").GetComponent<AudioSource>();
        getstar = GameObject.Find("getstarSE").GetComponent<AudioSource>();
        checkpoint = GameObject.Find("checkpointSE").GetComponent<AudioSource>();
        buzz = GameObject.Find("buzzSE").GetComponent<AudioSource>();
        bomb = GameObject.Find("bombSE").GetComponent<AudioSource>();
        enemyshoot = GameObject.Find("enemyshootSE").GetComponent<AudioSource>();
        rock = GameObject.Find("rockSE").GetComponent<AudioSource>();
        teleport = GameObject.Find("teleportSE").GetComponent<AudioSource>();
        bossmove = GameObject.Find("bossmoveSE").GetComponent<AudioSource>();
        Do = GameObject.Find("DoSE").GetComponent<AudioSource>();
        Mi = GameObject.Find("MiSE").GetComponent<AudioSource>();
        Sol = GameObject.Find("SolSE").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playbalance(){
        balance.Play();
    }

    public void Playdroptrap(){
        droptrap.Play();
    }

    public void Playscissors(){
        scissors.Play();
    }

    public void Playtrigger(){
        trigger.Play();
    }

    public void Playdooropen(){
        dooropen.Play();
    }

    public void Playdash(){
        dash.Play();
    }

    public void Playjump(){
        jump.Play();
    }

    public void Playrecall(){
        recall.Play();
    }
    public void Playplayerdie(){
        playerdie.Play();
    }

    public void PlayCDboom(){
        CDboom.Play();
    }

    public void Playbugatk(){
        bugatk.Play();
    }

    public void PlayCDcountdown(){
        CDcountdown.Play();
    }

    public void Playslurp(){
        slurp.Play();
    }

    public void Playenemydie(){
        enemydie.Play();
    }

    public void Playcheckpoint(){
        checkpoint.Play();
    }

    public void Playgetstar(){
        getstar.Play();
    }

    public void Playbuzz(){
        buzz.Play();
    }
    public void Playbomb(){
        bomb.Play();
    }
    public void Playenemyshoot(){
        enemyshoot.Play();
    }
    public void Playrock(){
        rock.Play();
    }
    public void Playteleport(){
        teleport.Play();
    }
    public void Playbossmove(){
        bossmove.Play();
    }

    public void Playdo(){
        print("do");
        Do.Play();
    }

    public void Playmi(){
        Mi.Play();
    }

    public void Playsol()
    {
        Sol.Play();
    }
}
