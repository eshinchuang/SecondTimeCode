using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiBulletController : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float bulletLifetime;
    Vector2 target;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find("Player/player");
        Destroy(this.gameObject, bulletLifetime);
        target = player.transform.position;
        dir = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + dir.x, transform.position.y + dir.y), speed * Time.deltaTime);
        transform.Rotate(0, 0, 6);
        if(transform.position.y == target.y){
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Map"){
            // print("hit" + other.tag);
            Destroy(this.gameObject);
        }
    }
}
