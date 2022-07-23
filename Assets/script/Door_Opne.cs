using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Opne : MonoBehaviour
{
    private Animator anim;
    public GameObject a, b, c;
    GameObject SE;
    void Start()
    {
        anim = GetComponent<Animator>();
        SE = GameObject.Find("SEPlayer");
    }

    void Update()
    {
        if (a == null && b == null && c == null)
        {
            print("open");
            anim.SetBool("touch", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
