using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw_spin_control : MonoBehaviour
{
    GameObject SE;
    void Start()
    {
        SE = GameObject.Find("SEPlayer");
        SE.GetComponent<SEController>().Playrock();
    }

    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 3.0f);
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "player"){
            //Destroy(gameObject);
        }
    }
}
