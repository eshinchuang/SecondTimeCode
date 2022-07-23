using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            rb.AddForce(Vector2.up * 1800);
        }
    }
}
