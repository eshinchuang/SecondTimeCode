using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class starControll : MonoBehaviour
{
    public GameObject s1, s2, s3;
    GameObject SE;
    int stars;
    // Start is called before the first frame update
    void Start()
    {
        stars = GameObject.Find("BGM").GetComponent<Event>().Stars;
        SE = GameObject.Find("SEPlayer");
        s1.SetActive(false);
        s2.SetActive(false);
        s3.SetActive(false);
        starAnim();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void starAnim()
    {
        if (stars >= 1)
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.PrependInterval(0.3f);
            mySequence.OnKill(delegate { s1.SetActive(true); SE.GetComponent<SEController>().Playdo(); });
        } 
        if (stars >= 2) 
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.PrependInterval(0.6f);
            mySequence.OnKill(delegate{ s2.SetActive(true); SE.GetComponent<SEController>().Playmi(); });
        }
        if (stars >= 3)  
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.PrependInterval(0.9f);
            mySequence.OnKill(delegate{ s3.SetActive(true); SE.GetComponent<SEController>().Playsol(); });
        }
    }

    void StarEF(GameObject s)
    {
        s.SetActive(true);
    }
}
