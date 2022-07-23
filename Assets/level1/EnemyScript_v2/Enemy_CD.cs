using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CD : MonoBehaviour
{
    public float speed;
    public float sightRange;
    public float boomRange;
    public float boomTime;
    Animator CDAni;
    GameObject player;
    GameObject SE;
    public GameObject boom;
    private player2D player_cs;
    // public GameObject Boom;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        SE = GameObject.Find("SEPlayer");
        CDAni = this.gameObject.GetComponent<Animator>();
        CDAni.SetBool("booming", false);
        CDAni.SetBool("boom", false);
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(player.transform.position, transform.position);
        if(dis < sightRange && !CDAni.GetBool("boom")){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(dis < boomRange || CDAni.GetBool("booming")){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1.5f * speed * Time.deltaTime);
            if(!CDAni.GetBool("booming") && !CDAni.GetBool("boom")){
                SE.GetComponent<SEController>().PlayCDcountdown();
            }
            CDAni.SetBool("booming", true);
            boomTime -= Time.deltaTime;
            if (boomTime <= 0)
            {
                CDAni.SetBool("boom", true);
                CDAni.SetBool("booming", false);
                GameObject booming = Instantiate(boom, transform.position, Quaternion.identity);
                Destroy(booming, 0.5f);
                SE.GetComponent<SEController>().PlayCDboom();
                Destroy(this.gameObject, 0.5f);
            }
        }
        if(!CDAni.GetBool("boom"))
            transform.Rotate(new Vector3(0, 0, (CDAni.GetBool("booming") ? 10 : 2)));
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawWireSphere(transform.position, boomRange);
    }
}
