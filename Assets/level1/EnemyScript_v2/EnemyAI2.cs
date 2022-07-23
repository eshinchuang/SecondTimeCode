using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    public float left_border, right_border;
    public float walkSpeed;
    public float sightRange;
    float cooldown;
    public GameObject bullet;
    GameObject player;
    SpriteRenderer spr;
    Animator EnemyAni;
    private float speed;
    // private int state;
    public float sightTop;
    public float sightBottom;
    private Vector2 firepos;

    private bool is_dead;
    GameObject SE;
    
    // Start is called before the first frame update
    void Start()
    {
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        EnemyAni = this.gameObject.GetComponent<Animator>();
        speed = walkSpeed;
        player = GameObject.Find("player");
        SE = GameObject.Find("SEPlayer");
        EnemyAni.SetBool("shoot", true);
        is_dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < left_border && !spr.flipX){
            spr.flipX = true;
        }
        if(this.gameObject.transform.position.x > right_border && spr.flipX){
            spr.flipX = false;
        }

        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        if(is_dead){
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        if(spr.flipX){
            this.gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else{
            this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(player.transform.position.x < transform.position.x + sightRange && player.transform.position.x > transform.position.x && spr.flipX && this.gameObject.transform.position.x <= right_border && player.transform.position.y < sightTop && player.transform.position.y > sightBottom){
            speed = 0;
            Shoot();
            EnemyAni.SetBool("shoot", true);
        }
        else if(player.transform.position.x > transform.position.x - sightRange && player.transform.position.x < transform.position.x && !spr.flipX && this.gameObject.transform.position.x >= left_border && player.transform.position.y < sightTop && player.transform.position.y > sightBottom){
            speed = 0;
            Shoot();
            EnemyAni.SetBool("shoot", true);
        }
        else{
            speed = walkSpeed;
            EnemyAni.SetBool("shoot", false);
        }
    }

    private void Shoot(){
        firepos = new Vector2(transform.position.x, transform.position.y);
        if(cooldown <= 0){
            SE.GetComponent<SEController>().Playslurp();
            Instantiate(bullet, firepos, Quaternion.identity);
            cooldown = Random.Range(0.3f, 0.5f);
        }
        else{
            cooldown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "weapon"){
            is_dead = true;
            SE.GetComponent<SEController>().Playenemydie();
        }
    }
}
