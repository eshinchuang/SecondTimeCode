using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float left_border, right_border;
    public float runSpeed;
    public float walkSpeed;
    public float sightRange;
    public Animator EnemyAni;
    GameObject player;
    SpriteRenderer spr;
    private float speed;
    private float sightTop;
    private float sightBottom;

    private bool is_dead;
    GameObject SE;

    // Start is called before the first frame update
    void Start()
    {
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        speed = walkSpeed;
        player = GameObject.Find("player");
        SE = GameObject.Find("SEPlayer");
        sightTop = -1.5f;
        sightBottom = -3.9f;
        is_dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < left_border && spr.flipX){
            spr.flipX = false;
        }
        if(this.gameObject.transform.position.x > right_border && !spr.flipX){
            spr.flipX = true;
        }

        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void FixedUpdate() {
        if(!spr.flipX){
            this.gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else{
            this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(player.transform.position.x < transform.position.x + sightRange && player.transform.position.x > transform.position.x && !spr.flipX && this.gameObject.transform.position.x <= right_border && player.transform.position.y < sightTop && player.transform.position.y > sightBottom){
            speed = runSpeed;
            EnemyAni.SetBool("Tracing", true);
        }
        else if(player.transform.position.x > transform.position.x - sightRange && player.transform.position.x < transform.position.x && spr.flipX && this.gameObject.transform.position.x >= left_border && player.transform.position.y < sightTop && player.transform.position.y > sightBottom){
            speed = runSpeed;
            EnemyAni.SetBool("Tracing", true);
        }
        else{
            speed = walkSpeed;
            EnemyAni.SetBool("Tracing", false);
        }

        if(is_dead){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "weapon"){
            is_dead = true;
            SE.GetComponent<SEController>().Playenemydie();
        }
    }
}
