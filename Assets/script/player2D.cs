using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class player2D : MonoBehaviour
{
    public GameObject shadow, dashOBj;
    camera_control cam;
    player_control pc;
    public float maxSpeed = 10.0f;
    public float jumpForce = 300.0f;
    float CurMaxSpeed;
    float CurSpeed;
    float dashTime;
    Rigidbody2D rb;
    Collider2D cld;
    public bool airControl = true;
    bool facingRight;
    public static bool timestop;
    public  bool canControll, takeback;
    ParticleSystemRenderer ps;

    public LayerMask groundLayer;
    private float moveDir;

    //public GameObject weapon;
    public Transform groundCheck;
    float groundRadius;
    bool onGround, isDash, Dashcd, IsBoss;

    float spawntime, distance;
    Animator anim, swdanim;
    public GameObject Return;
    ParticleSystem ReturnP;

    Vector2 spot, startplace;

    private Vector3 init_pos;
    public bool is_dead, returning;
    public GameObject relive;
    float a;
    GameObject evnt;
    GameObject SE;
    int CurSave;

    private bool can_die;
    private GameObject shadow_pos;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cld = GetComponent<Collider2D>();
        cam = GameObject.Find("Main Camera").GetComponent<camera_control>();
        pc = GetComponent<player_control>();
        ps = dashOBj.GetComponent<ParticleSystemRenderer>();
        ReturnP = Return.GetComponent<ParticleSystem>();
        anim.SetBool("Die",false);
        facingRight = true;
        groundRadius = 0.2f;
        onGround = false;
        Dashcd = true;
        CurSave = GameObject.Find("BGM").GetComponent<Event>().CurSavepoint;
        evnt = GameObject.Find("BGM");
        Startplace(CurSave);
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Start()
    {
        Time.timeScale = 1;
        init_pos = gameObject.GetComponent<Transform>().position;
        is_dead = false;
        returning = false;
        SE = GameObject.Find("SEPlayer");
        can_die = true;
        shadow_pos = GameObject.Find("shadow");
        shadow_pos.gameObject.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
        //startplace = transform.position;
        //Instantiate(relive, startplace + new Vector2(0, -1), relive.transform.rotation);

    }

    void Update()
    {   
        spot = shadow.transform.position;
        moveDir = transform.localScale.x;
		if (Input.GetKey(KeyCode.LeftShift)){
            CurMaxSpeed = 3;
        }
        else{
            CurMaxSpeed = 10;
        }

        if (onGround){
            maxSpeed = CurMaxSpeed;
        }

        if ( (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) ) && Dashcd && onGround){
            var c = SE.GetComponents(typeof(Component));
            print(c);
            foreach(var n in c){
                print(n);
            }
            anim.SetBool("Dashing", true);
            SE.GetComponent<SEController>().Playdash();
            isDash = true;
            dashOBj.SetActive(true);
            dashTime = 0.2f;
        }
        Dash();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.K)){
            can_die = false;
        }else if(Input.GetKey(KeyCode.L)){
            can_die = true;
        }

        if(rb.velocity.y <= -30) rb.velocity = new Vector2(rb.velocity.x, -30);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        if(!is_dead)
            anim.SetBool("OnGround", onGround);
    }

    void Dash(){
        if (dashTime <= 0)
        {
            dashOBj.SetActive(false);
            anim.SetBool("Dashing", false);
            isDash = false;
            dashTime = 0;
            return;
        }
        if(isDash){
            Dashcd = false;
            float DashSpeed = 1300f;
            
            float dirx;
            if(transform.localScale.x >= 0) dirx = 1;
            else dirx = -1;
            Vector2 dir = new Vector2(dirx, 0);
            if(!is_dead)
                rb.AddForce(dir * DashSpeed);
            ps.flip = new Vector3( (dirx < 0)? 1 : 0, 0, 0);
            Invoke("DashCD", 1.0f);
        }
        dashTime = dashTime - Time.deltaTime;
    }

    public void Move(float movingSpeed, bool jump)
    {   
        if (onGround || airControl)
        {
            anim.SetFloat("speed", Mathf.Abs(movingSpeed));
            CurSpeed = movingSpeed * maxSpeed * 0.1f;
            anim.SetFloat("CurSpeed", Mathf.Abs(CurSpeed));
            rb.velocity = new Vector2(movingSpeed * maxSpeed + a, GetComponent<Rigidbody2D>().velocity.y);

            if (movingSpeed > 0 && !facingRight || movingSpeed < 0 && facingRight) Flip();
        }

        if (onGround && jump)
        {
            SE.GetComponent<SEController>().Playjump();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce)*2);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }
    
	public void DashCD(){
		Dashcd = true;
	}
    public void Spawn()
    {
        SE.GetComponent<SEController>().Playrecall();
        anim.SetBool("Die", false);
        is_dead = false;
        cld.enabled = true;
        returning = true;
        Time.timeScale = 0;
        takeback = false;
        rb.velocity = Vector2.zero;
        GameObject copy = Instantiate(Return, transform.position, new Quaternion(0, 0, 0, 0));
        Sequence mySequence = DOTween.Sequence();
        mySequence.SetUpdate(true);
        mySequence.PrependInterval(0.4f);
        mySequence.Append(transform.DOMove(spot, 0));
        mySequence.Append(copy.transform.DOMove(spot, 0));
        mySequence.OnKill(delegate
        {
            Time.timeScale = 1.0f;
            cam.redo();
            takeback = true;
            Invoke("notR", 0.5f);
            Destroy(copy, 1);
        });
    }

    void notR()
    {
        returning = false;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "enemy" || col.gameObject.tag == "spike"){
            if(can_die) Die();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "enemy" || col.gameObject.tag == "spike"){
            if(can_die) Die();
        }
        if (col.gameObject.tag == "Goal")
        {
            Goal();
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "moveplatform")
        {   
            a = col.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        a = 0;
    }

    void revive()
    {
        evnt.GetComponent<BGMController>().DieInBossRoom();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Die(){
        anim.SetBool("Die", true);
        Time.timeScale = 0.25f;
        is_dead = true;
        cld.enabled = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 500);
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(0.5f);
        mySequence.OnKill(delegate
            {   
                if(!returning)
                    revive(); }
        );
        
    }

    void Goal(){
        evnt.GetComponent<Event>().Goal();
    }

    void Startplace(int point)
    {
        if (point == 0){
            transform.position = GameObject.Find("StartPoint").GetComponent<Transform>().position;
        }
        if (point == 1)
        {
            transform.position = GameObject.Find("CheckPoint").GetComponent<Transform>().position + new Vector3(0,-1, 0);
        }
        if (point == 2)
        {
            transform.position = GameObject.Find("CheckPoint2").GetComponent<Transform>().position + new Vector3(0,-1, 0);
        }
        if (point == 3)
        {
            transform.position = GameObject.Find("CheckPoint3").GetComponent<Transform>().position + new Vector3(0,-1, 0);
        }
        if (point == 4)
        {
            transform.position = GameObject.Find("CheckPoint4").GetComponent<Transform>().position + new Vector3(0,-1, 0);
        }
    }
}
