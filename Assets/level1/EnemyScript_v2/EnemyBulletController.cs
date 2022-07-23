using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    GameObject player;
    public float speed;
    private bool left;
    private SpriteRenderer spr;
    public float bulletLifetime;
    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find("Player/player");
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        Destroy(this.gameObject, bulletLifetime);
        left = (transform.position.x > player.transform.position.x);
        spr.flipX = left;
    }

    // Update is called once per frame
    void Update()
    {
        // this.gameObject.transform.position += gameObject.transform.up * speed * Time.deltaTime;
        if(left){
            this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else{
            this.gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // print("Hit" + other.tag);
        if(other.tag == "Player" || other.tag == "Map"){
            // print("hit" + other.tag);
            Destroy(this.gameObject);
        }
    }
}
