using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour
{
    public GameObject bullet;
    Vector2 start;
    GameObject copy;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position + new Vector3(0, 16, 0);
        Invoke("Copy", 0.5f);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Copy()
    {
        
        copy = Instantiate(bullet, start, Quaternion.identity);
    }
}
