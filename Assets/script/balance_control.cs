using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance_control : MonoBehaviour
{
    GameObject SE;
    private Animator anim;
    private Animator anim_balance;
    private bool is_open;
    private GameObject left_collider;
    private GameObject right_collider;
    private GameObject door;

    private int cnt;
    private bool flag;

    void Start()
    {
        anim = GameObject.Find("door_balance").gameObject.GetComponent<Animator>();
        anim_balance = GameObject.Find("balance").gameObject.GetComponent<Animator>();
        is_open = false;
        SE = GameObject.Find("SEPlayer");
        right_collider = GameObject.Find("right_collider");
        left_collider = GameObject.Find("left_collider");
        door = GameObject.Find("door_balance");
        cnt = 0;
        flag = false;
    }

    void Update()
    {
        if(flag){
            cnt++;
            if(cnt == 200){
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
            anim_balance.SetBool("is_stand", true);
            SE.GetComponent<SEController>().Playbalance();
            is_open = true;
            right_collider.GetComponent<Transform>().position -= new Vector3(0.0f, 0.8f, 0.0f);
            left_collider.GetComponent<Transform>().position += new Vector3(0.0f, 0.8f, 0.0f);
            door.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.name == "player" && is_open){
            anim_balance.SetBool("is_stand", false);
            SE.GetComponent<SEController>().Playbalance();
            is_open = false;
            right_collider.GetComponent<Transform>().position += new Vector3(0.0f, 0.8f, 0.0f);
            left_collider.GetComponent<Transform>().position -= new Vector3(0.0f, 0.8f, 0.0f);
            flag = true;
        }
    }

}
