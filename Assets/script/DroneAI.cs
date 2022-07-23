using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DroneAI : MonoBehaviour
{
    Animator anim;
    public float way;
    float time, speed;
    float frq, cooldown;
    public GameObject bullet;
    GameObject player;
    Rigidbody2D rb;
    GameObject SE;
    // Start is called before the first frame update
    void Start()
    {
        SE = GameObject.Find("SEPlayer");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        frq = 3;
        InvokeRepeating("Flip", 0, 3);
        player = GameObject.Find("Player/player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2 * frq) time = 0;
        else if (time <= frq && time >= 0.5f) rb.velocity = Vector2.right * speed * way;
        else if (time <= 2 * frq && time >= frq + 0.5f) rb.velocity = Vector2.left * speed * way;

        float dis = Vector2.Distance(player.transform.position, transform.position);
        if(dis < 8.0f){
            Shoot();
        }
    }
    void Flip()
    {
        anim.SetBool("turn", true);
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(0.5f);
        mySequence.OnKill(delegate
        {
            anim.SetBool("turn", false);
            Vector3 characterScale = transform.localScale;
            characterScale.x *= -1;
            transform.localScale = characterScale;     
        });
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapon")
        {
            anim.SetBool("Die", true);
            Destroy(gameObject, 0.5f);   
        }
    }


    private void Shoot()
    {
        //SE.GetComponent<SEController>().Playenemyshoot();
        Vector2 firepos = new Vector2(transform.position.x, transform.position.y);
        if(cooldown <= 0){
            Instantiate(bullet, firepos, Quaternion.identity);
            cooldown = Random.Range(1.0f, 1.5f);
        }
        else{
            cooldown -= Time.deltaTime;
        }
    }
}
