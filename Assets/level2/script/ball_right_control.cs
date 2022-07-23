using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_right_control : MonoBehaviour
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
        if(cnt == 100){
            cnt = 0;
            ins_ball = Instantiate(ball, pos, Quaternion.identity);
            ins_ball.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 650);
        }
    }

}
