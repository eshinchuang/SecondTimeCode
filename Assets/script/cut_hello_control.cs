using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut_hello_control : MonoBehaviour
{
    private GameObject put_not;
    private Vector3 init_pos;

    void Start()
    {
        put_not = GameObject.Find("helloworld");
        init_pos = GameObject.Find("helloworld").gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
        put_not.gameObject.GetComponent<Transform>().position = init_pos;
        put_not.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "weapon"){
            put_not.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(gameObject);
        }
    }
}
