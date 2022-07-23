using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI3 : MonoBehaviour
{
    float cooldown;
    public GameObject bullet;
    GameObject player;
    Animator EnemyAni;
    SpriteRenderer spr;
    private float speed;
    private Vector2 firepos1;
    private Vector2 firepos2;

    private bool is_dead;
    GameObject SE;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        EnemyAni = this.gameObject.GetComponent<Animator>();
        EnemyAni.SetBool("attack", false);
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        SE = GameObject.Find("SEPlayer");
        spr.flipX = false;
        is_dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        spr.flipX = (player.transform.position.x > transform.position.x) ? true : false;

        if(is_dead){
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        if(EnemyAni.GetBool("attack")){
            EnemyAni.SetBool("attack", false);
        }
        Shoot();
    }

    private void Shoot(){
        if(cooldown <= 0){
            SE.GetComponent<SEController>().Playbugatk();
            EnemyAni.SetBool("attack", true);
            firepos1 = new Vector3(transform.position.x - 0.1f, transform.position.y + 0.1f, 0.0f);
            firepos2 = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.1f, 0.0f);
            Instantiate(bullet, firepos1, Quaternion.identity);
            Instantiate(bullet, firepos2, Quaternion.identity);
            cooldown = Random.Range(2.0f, 2.5f);
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
