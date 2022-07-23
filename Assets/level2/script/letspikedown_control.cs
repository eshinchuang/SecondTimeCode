using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letspikedown_control : MonoBehaviour
{

    private bool can_fall;
    private int cnt;
    private int count;

    void Start()
    {
        cnt = 0;
        count = 0;
    }

    void Update()
    {
        if(can_fall){
            count++;
            if(count == 5 && cnt < 20){
                count = 0;
                string name = "fall" + cnt;
                if(GameObject.Find(name)) GameObject.Find(name).gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                cnt++;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "player"){
            can_fall = true;
            Destroy(gameObject, 5);
        }
    }
}
