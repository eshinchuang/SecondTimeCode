using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{
    GameObject SE;
    GameObject BGM;
    public GameObject bullet, ef, warn, DieAnim;
    GameObject lightning, player;

    Rigidbody2D rb;
    Animator anim;

    public float speed;
    float time, pos;
    public float dir;
    int HP;
    bool is_dead, active;

    private GameObject boss_health;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        SE = GameObject.Find("SEPlayer");
        BGM = GameObject.Find("BGMPlayer");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //DieAnim = GameObject.Find("explode");
        lightning = GameObject.Find("Lightning");
        player = GameObject.Find("player");
        lightning.SetActive(false);
        dir = 1;
        HP = 3;
        pos = 220;
        //DieAnim.SetActive(false);
        is_dead = false;
        boss_health = GameObject.Find("boss_health");
        boss_health.SetActive(false);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        active = GameObject.Find("bosss").GetComponent<IsBossFight>().IsBoss;
        if(active){
            boss_health.SetActive(true);
            cam.orthographicSize = 15.0f;
            if (!is_dead)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    time = 3;
                    Flip();
                    Invoke("Attack", 0.5f);
                }
                else if (time < 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos, transform.position.y), 15 * Time.deltaTime);
                }
                else if (time == 1)
                {
                    SE.GetComponent<SEController>().Playbossmove();
                }
                else{
                    while( Mathf.Abs(pos - transform.position.x)  < 6)
                        pos = Random.Range(206, 240);
                }
            }
        }
    }

    void Flip()
    {
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        if (characterScale.x < 0 && (player.transform.position.x - transform.position.x) > 0)  {
            transform.localScale = characterScale;
            dir *= -1;
        }
        else if (characterScale.x > 0 && (player.transform.position.x - transform.position.x) < 0)
        {
            transform.localScale = characterScale;
            dir *= -1;
        }
    }

    void Attack()
    {
        int a = Random.Range(0, 3);
        if (a == 0)
        {
            Shoot();
            Invoke("Shoot", 0.3f);
            Invoke("Shoot", 0.6f);
        }
        if (a == 1)
        {
            GameObject eff = Instantiate(ef, transform.position, Quaternion.identity);
            Destroy(eff, 1);
            Invoke("Thunder", 1);
        }
        if (a == 2)
        {
            Invoke("warning", 0.5f);
            Invoke("warning", 1);
            Invoke("warning", 1.5f);
        }
    }

    void Shoot()
    {
        SE.GetComponent<SEController>().Playenemyshoot();
        Vector2 firepos = GameObject.Find("fire").GetComponent<Transform>().position;
        Instantiate(bullet, firepos, Quaternion.identity);
    }

    void Thunder()
    {
        SE.GetComponent<SEController>().Playbuzz();
        lightning.SetActive(true);
        Invoke("close", 1);
    }

    void close()
    {
        lightning.SetActive(false);
    }
    void warning()
    {
        float place = Random.Range(200, 246);
        Instantiate(warn, new Vector2(place, -106), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapon")
        {
            anim.SetBool("hurt", true);
            print(HP);
            Invoke("nothurt", 0.5f);
            HP -= 1;
            GameObject.Find("hurt").gameObject.GetComponent<Image>().fillAmount -= 0.34f;
            if (HP <= 0){
                Die();
                cam.orthographicSize = 8.57f;
            }
        }

    }

    void nothurt()
    {
        anim.SetBool("hurt", false);
    }

    void Die()
    {
        //BGM.GetComponent<BGMController>().BossDied();
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        is_dead = true;
        for (float i = 0; i < 2; i = i + 0.5f)
        {
            Invoke("booming", i);           
        }
        Destroy(gameObject, 2);
    }

    void booming()
    {
            SE.GetComponent<SEController>().Playbomb();
            float poss = Random.Range(-3.0f, 3.0f);
            GameObject copy = Instantiate(DieAnim, new Vector2(transform.position.x + poss, transform.position.y + poss), Quaternion.identity);
            Destroy(copy, 0.5f);
    }
}
