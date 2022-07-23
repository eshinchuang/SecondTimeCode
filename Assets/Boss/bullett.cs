using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullett : MonoBehaviour
{

    Vector2 start;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 18 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Map"){
            Destroy(this.gameObject);
        }
    }
}
