using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquitmentController : MonoBehaviour
{
    GameObject player;
    bool p;
    Vector2 target;
    Vector2 dir;
    float speed;
    camera_control cc;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        cc = GameObject.Find("Main Camera").GetComponent<camera_control>();
        speed = (player.transform.position - transform.position).magnitude;
        if(speed < 11) speed = 11;
    }

    // Update is called once per frame
    void Update()
    {
        p = player.GetComponent<player2D>().takeback;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3 * speed * Time.deltaTime);
        transform.right = player.transform.position - transform.position;
        if(p && (transform.position == player.transform.position ) ){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        if (col.gameObject.tag == "enemy"){
            GameObject copy = Instantiate(effect, col.transform.position, new Quaternion(0, 0, 0, 0));
            print("kill");
            cc.shake();
        }
    }

    // void OnCollisionEnter2D(Collision2D col){
    //     if(col.gameObject.tag != "enemy"){
    //         this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    //     }
    // }
}
