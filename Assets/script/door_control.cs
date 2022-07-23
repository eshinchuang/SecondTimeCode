using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_control : MonoBehaviour
{
    private Animator anim;
    private Animator anim_btn;
    private bool is_open;
    private GameObject door;

    private int cnt;
    private bool flag;
    GameObject SE;

    void Start()
    {
        anim = GameObject.Find("door_button").gameObject.GetComponent<Animator>();
        anim_btn = GameObject.Find("door_control").gameObject.GetComponent<Animator>();
        SE = GameObject.Find("SEPlayer");
        is_open = false;
        door = GameObject.Find("door_button");
        cnt = 0;
        flag = false;
    }

    void FixedUpdate()
    {
        if(flag){
            cnt++;
            if(cnt == 30){
                flag = false;
                cnt = 0;
                anim.SetBool("touch", false);
                door.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "player" && !is_open){
            anim.SetBool("touch", true);
            anim_btn.SetBool("is_stand", true);
            is_open = true;
            SE.GetComponent<SEController>().Playdooropen();
            SE.GetComponent<SEController>().Playtrigger();
            door.gameObject.GetComponent<BoxCollider2D>().enabled = false;
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
