using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControll : MonoBehaviour
{
    public int num;
    while_control trap;
    public GameObject t;
    int cur;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        cur = GameObject.Find("trap3/while_detect").GetComponent<while_control>().WC;
        if (num == cur)
        {
            t.SetActive(false);
        }
        else t.SetActive(true);
    }
}
