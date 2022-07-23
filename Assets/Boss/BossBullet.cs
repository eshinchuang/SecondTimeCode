using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float bulletLifetime;
    Rigidbody2D  rb;
    Vector2 target;
    float dir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, bulletLifetime);
        dir = GameObject.Find("Boss").GetComponent<BossAI>().dir;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dir, 0) * 10;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Map"){
            Destroy(this.gameObject);
        }
    }
}
