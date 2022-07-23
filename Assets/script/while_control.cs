using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class while_control : MonoBehaviour
{

    private ParticleSystem detect_effect;
    public GameObject de;
    public int WC;
    GameObject SE;

    void Start()
    {
        //de = GameObject.Find("trap3/while_effect");
        SE = GameObject.Find("SEPlayer");
        de.SetActive(false);
        WC = 0;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "put_not")
        {
            WC = 1;
            de.SetActive(true);
            SE.GetComponent<SEController>().Playdooropen();
        }
    }
}
