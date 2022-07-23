using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savepoint : MonoBehaviour
{
    public GameObject ef;
    bool firstTime;
    GameObject SE;
    public int num;
    Event ev;
    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
        SE = GameObject.Find("SEPlayer");
        ev = GameObject.Find("BGM").GetComponent<Event>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "player" && firstTime)
        {
            GameObject copy = Instantiate(ef, transform.position, new Quaternion(0, 0, 0, 0));
            firstTime = false;
            SE.GetComponent<SEController>().Playcheckpoint();
            ev.CurSavepoint = num;
            Destroy(copy, 2);
        }
    }
}
