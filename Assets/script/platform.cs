using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float way;
    float frq, time;
    float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        frq = 2;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 2 * frq;
        }
        else if (time <= frq)
        {
            rb.velocity = Vector2.right * speed * way;
        }
        else if (time <= frq* 2)
        {
             rb.velocity = Vector2.left * speed * way;
        }
    }
}
