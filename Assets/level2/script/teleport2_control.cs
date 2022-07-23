using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport2_control : MonoBehaviour
{
    public int state;

    private Vector3 pos;

    GameObject SE;

    void Start()
    {
        state = 0;
        SE = GameObject.Find("SEPlayer");
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "player"){
            if(state == 0){
                pos = GameObject.Find("teleport_door1").GetComponent<Transform>().position;
                GameObject.Find("player").GetComponent<Transform>().position = pos - new Vector3(2.0f, 0.0f, 0.0f);
            }else{
                pos = GameObject.Find("teleport_door4").GetComponent<Transform>().position;
                GameObject.Find("player").GetComponent<Transform>().position = pos + new Vector3(3.5f, 0.0f, 0.0f);
            }
            SE.GetComponent<SEController>().Playteleport();
        }
    }
}
