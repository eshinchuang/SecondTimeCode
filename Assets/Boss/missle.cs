using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float bulletLifetime;
    Rigidbody2D  rb;
    Vector2 target;
    float dirx, diry;
    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find("player");
        Destroy(this.gameObject, bulletLifetime);
        target = player.transform.position;
        rb = GetComponent<Rigidbody2D>();
        dirx = (target.x - transform.position.x > 0) ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
        if (target.y - transform.position.y > 0) diry = 1;
        else if (target.y - transform.position.y < 0) diry = -1;
        else if (target.y - transform.position.y == 0) diry = 0;
        if ((target.x - transform.position.x > 0 && dirx > 0)  ||  (target.x - transform.position.x < 0 && dirx < 0) )
        {
            rb.velocity = new Vector2(dirx, diry * 0.4f) * speed;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y) ;
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Map"){
            Destroy(this.gameObject);
        }
    }
}
