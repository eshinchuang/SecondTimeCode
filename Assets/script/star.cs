using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public GameObject ef;
    bool firstTime;
    GameObject SE;
    public int starnum;
    Event ev;
    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
        SE = GameObject.Find("SEPlayer");
        ev = GameObject.Find("BGM").GetComponent<Event>();
        if (ev.star[starnum] == 1)
        {
            this.gameObject.SetActive(false);
        }
        else
            this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "player" && firstTime)
        {
            GameObject copy = Instantiate(ef, transform.position, new Quaternion(0, 0, 0, 0));
            firstTime = false;
            SE.GetComponent<SEController>().Playgetstar();
            this.gameObject.SetActive(false);
            ev.Stars += 1;
            ev.star[starnum] = 1;
            Destroy(copy, 2);
        }
    }
}
