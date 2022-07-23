using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControll : MonoBehaviour
{   
    Animator anim_btn;
    private bool is_open;
    public GameObject plat;

    private int cnt;
    private bool flag;
    GameObject SE;

    void Start()
    {
        anim_btn = GetComponent<Animator>();
        SE = GameObject.Find("SEPlayer");
        is_open = false;
        cnt = 0;
        flag = false;
        plat.SetActive(false);
    }

    void FixedUpdate()
    {
        if(flag){
            cnt++;
            if(cnt == 100){
                flag = false;
                cnt = 0;
                plat.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "player" && !is_open){
            anim_btn.SetBool("is_stand", true);
            is_open = true;
            SE.GetComponent<SEController>().Playtrigger();
            plat.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.name == "player" && is_open){
            anim_btn.SetBool("is_stand", false);
            is_open = false;
            flag = true;
        }
    }   
}
