using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour
{
    public float awaketime;
    public GameObject NxtShadow;
    float curTime;
    float direction;
    Transform target;
    Vector2 To;
    float distance;
    Animator anim;
    Rigidbody2D rb;
    bool facingRight;
    public bool Dashing, OnGround;
    public float speed, curspeed; 
    void Start()
    {   
        StartCoroutine(A());
        target = NxtShadow.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator A(){
        yield return new WaitForSeconds(awaketime);
    }
    // Update is called once per frame
    void Update()
    {   
        if( curTime >= 0.25f){
            curTime = 0;
            direction = ((target.position.x - transform.position.x)> 0 ? 1 : -1);
            distance = Vector2.Distance(transform.position, target.position);
            if(awaketime == 0.25){
                Dashing = NxtShadow.GetComponent<Animator>().GetBool("Dashing");
                OnGround = NxtShadow.GetComponent<Animator>().GetBool("OnGround");
                speed = NxtShadow.GetComponent<Animator>().GetFloat("speed");
                curspeed = NxtShadow.GetComponent<Animator>().GetFloat("CurSpeed");
            }
            else{
                Dashing = NxtShadow.GetComponent<shadow>().Dashing;
                OnGround = NxtShadow.GetComponent<shadow>().OnGround;
                speed = NxtShadow.GetComponent<shadow>().speed;
                curspeed = NxtShadow.GetComponent<shadow>().curspeed;
            }
            To = target.position;
        }else{
            transform.position = Vector2.MoveTowards(transform.position, To , (distance/0.25f)* Time.deltaTime);
            curTime += Time.deltaTime;
        }
        if (direction < 0 && !facingRight || direction > 0 && facingRight) Flip();
        if (this.anim != null){
            anim.SetBool("Dashing",Dashing);
            anim.SetBool("OnGround",OnGround);
            anim.SetFloat("speed",speed);
            anim.SetFloat("CurSpeed",curspeed);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }
}
