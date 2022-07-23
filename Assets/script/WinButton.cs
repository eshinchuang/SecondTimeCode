using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButton : MonoBehaviour
{
    
    GameObject BGM;
    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("BGM");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Menu()
    {
        BGM.GetComponent<Event>().Menu();
    }
}
