using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBossFight : MonoBehaviour
{
    GameObject boss, BGM;
    public bool IsBoss;
    // Start is called before the first frame update
    void Start()
    {
        IsBoss = false;
        BGM = GameObject.Find("BGM");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            BGM.GetComponent<BGMController>().BossStage();
            GetComponent<Collider2D>().enabled = false;
            IsBoss = true;
        }
    }
}
