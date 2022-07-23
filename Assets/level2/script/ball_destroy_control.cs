using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_destroy_control : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0.0f, 0.0f, -3.0f);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Map"){
            Destroy(this.gameObject);
        }
    }
}
