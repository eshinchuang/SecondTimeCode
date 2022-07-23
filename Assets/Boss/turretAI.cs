using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour
{
    public GameObject missle;
    float cooldown;
    Animator anim;
    GameObject SE;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        SE = GameObject.Find("SEPlayer");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        active = GameObject.Find("bosss").GetComponent<IsBossFight>().IsBoss;
        if(active)
            Shoot();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapon")
        {
            anim.SetBool("Die", true);
            Destroy(gameObject, 0.5f);   
        }
    }

    
    private void Shoot(){
        Vector2 firepos = new Vector2(transform.position.x, transform.position.y);
        if (cooldown <= 0)
        {
            SE.GetComponent<SEController>().Playenemyshoot();
            Instantiate(missle, firepos, Quaternion.identity);
            cooldown = 3.0f;
        }
        else{
            cooldown -= Time.deltaTime;
        }
    }
}
