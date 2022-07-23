using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_control : MonoBehaviour
{
    private player2D character;
    Animator time;
    public GameObject weapon;


    private float movingSpeed;
    public float CD;

    bool canReverse;
    private bool jump;
    

    void Start()
    {
        character = GetComponent<player2D>();
        time = GameObject.Find("UI/Image").GetComponent<Animator>();
        CD = 2;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            jump = true;
        if (Input.GetKeyDown(KeyCode.R) && canReverse){
            Vector2 oldpos = transform.position;
            if(!character.is_dead) Instantiate(weapon, oldpos, Quaternion.identity);
            character.Spawn();
            startCD();
        }
    }

    void FixedUpdate()
    {
        movingSpeed = Input.GetAxis("Horizontal");
        character.Move(movingSpeed, jump);
        jump = false;
        if(!canReverse){
            if(CD <= 0){
                time.SetBool("CD", true);
                canReverse = true;
            }
            else
                CD -= Time.deltaTime;
        }
    }

    public void startCD()
    {
            time.SetBool("CD", false);
            canReverse = false;
            CD = 2.5f;
    }
}