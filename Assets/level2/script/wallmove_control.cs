using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmove_control : MonoBehaviour
{
    GameObject player;
    float movingSpeed;
    Rigidbody2D rb;
    private bool is_in;

    void Start()
    {
        is_in = false;
        player = GameObject.Find("player");
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        movingSpeed = Input.GetAxis("Horizontal");
        if(this.gameObject.transform.position.x - player.gameObject.transform.position.x <= 10.0f && Mathf.Abs(player.gameObject.transform.position.y - this.gameObject.transform.position.y) < 10.0f){
            is_in = true;
        }

        if(is_in){
            if(this.gameObject.transform.position.x < 130){
                if(this.gameObject.transform.position.x > 100){
                    rb.velocity = new Vector2(movingSpeed * 10, 0);
                }
                else{
                    if(movingSpeed < 0){
                        rb.velocity = Vector2.zero;
                    }
                    else{
                        rb.velocity = new Vector2(movingSpeed * 10, 0);
                    }
                }
            }
            else{
                if(movingSpeed < 0){
                    rb.velocity = new Vector2(movingSpeed * 10, 0);
                }
                else{
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }
}
