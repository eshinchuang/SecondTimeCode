using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    private Animator anim;
    GameObject SE;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        SE = GameObject.Find("SEPlayer");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("touch", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;     
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("touch", false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
