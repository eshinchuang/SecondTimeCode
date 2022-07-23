using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportall_control : MonoBehaviour
{
    private int door1_state;
    private int door2_state;
    private Animator anim;
    private Animator door1_anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        door1_anim = GameObject.Find("teleport_door1").gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "player"){
            door1_state = GameObject.Find("teleport_door1").gameObject.GetComponent<teleport1_control>().state;
            door2_state = GameObject.Find("teleport_door2").gameObject.GetComponent<teleport2_control>().state;
            if(door1_state == 0){
                GameObject.Find("teleport_door1").gameObject.GetComponent<teleport1_control>().state = 1;
                GameObject.Find("teleport_door2").gameObject.GetComponent<teleport2_control>().state = 1;
                anim.SetBool("is_on", true);
                door1_anim.SetBool("is_open", true);
            }else{
                GameObject.Find("teleport_door1").gameObject.GetComponent<teleport1_control>().state = 0;
                GameObject.Find("teleport_door2").gameObject.GetComponent<teleport2_control>().state = 0;
                anim.SetBool("is_on", false);
                door1_anim.SetBool("is_open", false);
            }
        }
    }
}
