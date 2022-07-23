using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camera_control : MonoBehaviour
{
    private GameObject player;
    private Vector3 player_pos;
    private Vector3 cam_pos;
    public bool bossfight;
    Vector3 initial;
    void Start()
    {
        player = GameObject.Find("player");
        initial = transform.position;
    }

    void FixedUpdate()
    {
        if (!bossfight)
        {
            player_pos = player.gameObject.GetComponent<Transform>().position;
            cam_pos = gameObject.GetComponent<Transform>().position;
            if(player_pos.x > cam_pos.x){
                gameObject.GetComponent<Transform>().position += new Vector3(player_pos.x - cam_pos.x, 0.0f, 0.0f);
            }else if(player_pos.x < cam_pos.x - 4.0f){
                gameObject.GetComponent<Transform>().position -= new Vector3(cam_pos.x - 4.0f - player_pos.x, 0.0f, 0.0f);
            }

            if(player_pos.y > cam_pos.y + 4.0f){
                gameObject.GetComponent<Transform>().position += new Vector3(0.0f, player_pos.y - (cam_pos.y + 4.0f), 0.0f);
            }else if(player_pos.y < cam_pos.y - 3.0f){
                gameObject.GetComponent<Transform>().position -= new Vector3(0.0f, cam_pos.y - 3.0f - player_pos.y, 0.0f);
            }
        }
        else
        {
        }
    }

    public void shake()
    {
        Tweener shaking = transform.DOShakePosition(0.4f, new Vector3(0.2f, 0, 0.2f));
    }
    public void redo(){
        transform.position = initial;
    }
}
