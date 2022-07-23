using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helloworld_control : MonoBehaviour
{
    private GameObject txt;
    public GameObject hello_effect;
    public GameObject detect_effect;

    void Start()
    {
        txt = GameObject.Find("helloworld_txt");
        txt.SetActive(false);
        //hello_effect = GameObject.Find("hello_effect");
        //detect_effect = GameObject.Find("detect_word_effect");
        hello_effect.SetActive(false);
        detect_effect.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "helloworld"){
            txt.SetActive(true);
            hello_effect.SetActive(true);
            detect_effect.SetActive(true);
            
        }
    }
}
