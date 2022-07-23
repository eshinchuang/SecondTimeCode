using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_control : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "box"){
            Debug.Log("success");
        }
    }
}
