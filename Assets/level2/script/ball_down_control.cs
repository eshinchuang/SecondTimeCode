using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_down_control : MonoBehaviour
{
    public GameObject ball;

    private int cnt;
    private Vector3 pos;
    private GameObject ins_ball;

    void Start()
    {
        cnt = 0;
        pos = gameObject.GetComponent<Transform>().position;
    }

    void FixedUpdate()
    {
        cnt++;
        if(cnt == 230){
            cnt = 0;
            ins_ball = Instantiate(ball, pos, Quaternion.identity);
            ins_ball.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-12.0f, -7.0f, 0.0f) * 300);
        }
    }
}
