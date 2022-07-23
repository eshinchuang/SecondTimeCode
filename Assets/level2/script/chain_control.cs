using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chain_control : MonoBehaviour
{
    private GameObject plat;

    void Start()
    {
        if(gameObject.transform.parent.gameObject.name == "chain1"){
            plat = GameObject.Find("platform1");
        }else if(gameObject.transform.parent.gameObject.name == "chain2"){
            plat = GameObject.Find("platform2");
        }else if(gameObject.transform.parent.gameObject.name == "chain3"){
            plat = GameObject.Find("platform3");
        }else if(gameObject.transform.parent.gameObject.name == "chain4"){
            plat = GameObject.Find("platform4");
        }else if(gameObject.transform.parent.gameObject.name == "chain5"){
            plat = GameObject.Find("platform5");
        }else if(gameObject.transform.parent.gameObject.name == "chain6"){
            plat = GameObject.Find("platform6");
        }else if(gameObject.transform.parent.gameObject.name == "chain7"){
            plat = GameObject.Find("platform7");
        }else if(gameObject.transform.parent.gameObject.name == "chain8"){
            plat = GameObject.Find("platform8");
        }else if(gameObject.transform.parent.gameObject.name == "chain9"){
            plat = GameObject.Find("platform9");
        }else if(gameObject.transform.parent.gameObject.name == "chain10"){
            plat = GameObject.Find("platform10");
        }else if(gameObject.transform.parent.gameObject.name == "chain11"){
            plat = GameObject.Find("platform11");
        }else if(gameObject.transform.parent.gameObject.name == "chain12"){
            plat = GameObject.Find("platform12");
        }else if(gameObject.transform.parent.gameObject.name == "chain13"){
            plat = GameObject.Find("platform13");
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "weapon"){
            plat.AddComponent<Rigidbody2D>();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
