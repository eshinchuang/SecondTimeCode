using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSaver : MonoBehaviour
{
    public int BGMVolume, SEVolume;
    public bool BGMMute, SEMute;
    // Start is called before the first frame update
    void Start()
    {
        BGMVolume = -25;
        SEVolume = -25;
        BGMMute = false;
        SEMute = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
