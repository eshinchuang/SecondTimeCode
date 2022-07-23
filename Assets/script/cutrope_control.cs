using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutrope_control : MonoBehaviour
{
    private GameObject put_not;
    private Vector3 init_pos;
    GameObject SE;

    void Start()
    {
        put_not = GameObject.Find("put_not");
        init_pos = GameObject.Find("put_not").gameObject.GetComponent<Transform>().position;
        SE = GameObject.Find("SEPlayer");
    }

    void Update()
    {
        put_not.gameObject.GetComponent<Transform>().position = init_pos;
        put_not.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "weapon"){
            put_not.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            SE.GetComponent<SEController>().Playscissors();
            Destroy(gameObject);
        }
    }
}
