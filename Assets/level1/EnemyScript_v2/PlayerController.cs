using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumppower;
    public GameObject equitment;
    private bool canJump;
    Vector3 atkpos;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        atkpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump){
            rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
            canJump = false;
        }  

        //attack
        if(Input.GetKeyDown(KeyCode.R)){
            Vector3 nowpos = transform.position;
            transform.position = atkpos;
            Instantiate(equitment, nowpos, Quaternion.identity);
        } 
    }

    private void FixedUpdate() {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX, rb.velocity.y/speed) * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            canJump = true;
        }
    }
}
