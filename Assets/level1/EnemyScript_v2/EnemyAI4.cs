using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI4 : MonoBehaviour
{
    public float speed;
    public float sightRange;
    public float boomRange;
    public float boomTime;
    Animator CDAni;
    GameObject player;
    GameObject SE;
    bool boomplayed;
    // public GameObject Boom;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        SE = GameObject.Find("SEPlayer");
        CDAni = this.gameObject.GetComponent<Animator>();
        CDAni.SetBool("booming", false);
        boomplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(player.transform.position, transform.position);
        if(dis < sightRange){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(dis < boomRange || CDAni.GetBool("booming")){
            if(!boomplayed){
                boomplayed = true;
                SE.GetComponent<SEController>().PlayCDcountdown();
            }
            CDAni.SetBool("booming", true);
            boomTime -= Time.deltaTime;
            print("booming");
            if(boomTime <= 0){
                print("enter CD");
                SE.GetComponent<SEController>().PlayCDboom();
                // var hurt = Instantiate(Boom, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        transform.Rotate(new Vector3(0, 0, (CDAni.GetBool("booming") ? 10 : 2)));
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawWireSphere(transform.position, boomRange);
    }
}
