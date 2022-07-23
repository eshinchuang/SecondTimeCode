using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeEditor : MonoBehaviour
{
    public AudioMixer Audio_Mixer;
    Slider BGMSlider;
    Slider SESlider;
    Toggle BGMMute;
    Toggle SEMute;
    Text BGMVolume;
    Text SEVolume;
    GameObject VolumeSaver;
    // Start is called before the first frame update
    void Start()
    {
        VolumeSaver = GameObject.Find("VolumeSaver");
        BGMSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        SESlider = GameObject.Find("SESlider").GetComponent<Slider>();
        BGMVolume = GameObject.Find("BGM_volume").GetComponent<Text>();
        SEVolume = GameObject.Find("SE_volume").GetComponent<Text>();
        BGMMute = GameObject.Find("BGMToggle").GetComponent<Toggle>();
        BGMMute.isOn = VolumeSaver.GetComponent<VolumeSaver>().BGMMute;
        SEMute = GameObject.Find("SEToggle").GetComponent<Toggle>();
        SEMute.isOn = VolumeSaver.GetComponent<VolumeSaver>().SEMute;
        BGMSlider.value = VolumeSaver.GetComponent<VolumeSaver>().BGMVolume;
        SESlider.value = VolumeSaver.GetComponent<VolumeSaver>().SEVolume;
        Audio_Mixer.SetFloat("BGMVolume", (VolumeSaver.GetComponent<VolumeSaver>().BGMMute) ? -80 : BGMSlider.value);
        Audio_Mixer.SetFloat("SEVolume", (VolumeSaver.GetComponent<VolumeSaver>().SEMute) ? -80 : SESlider.value);
        BGMVolume.GetComponent<Text>().text = (2 * BGMSlider.value + 100).ToString();
        SEVolume.GetComponent<Text>().text = (2 * SESlider.value + 100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BGMValueEdit(){
        if(BGMSlider.value == -50){
            BGMVolume.GetComponent<Text>().text = 0.ToString();
            Audio_Mixer.SetFloat("BGMVolume", -80);
        }
        else{
            Audio_Mixer.SetFloat("BGMVolume", BGMSlider.value);
            BGMVolume.GetComponent<Text>().text = (2 * BGMSlider.value + 100).ToString();
        }
        if(BGMMute.isOn) Audio_Mixer.SetFloat("BGMVolume", -80);
        VolumeSaver.GetComponent<VolumeSaver>().BGMVolume = (int)BGMSlider.value;
    }

    public void SEValueEdit(){
        if(SESlider.value == -50){
            SEVolume.GetComponent<Text>().text = 0.ToString();
            Audio_Mixer.SetFloat("SEVolume", -80);
        }
        else{
            Audio_Mixer.SetFloat("SEVolume", SESlider.value);
            SEVolume.GetComponent<Text>().text = (2 * SESlider.value + 100).ToString();
        }
        if(SEMute.isOn) Audio_Mixer.SetFloat("SEVolume", -80);
        VolumeSaver.GetComponent<VolumeSaver>().SEVolume = (int)SESlider.value;
    }

    public void ClickBGMMute(){
        Audio_Mixer.SetFloat("BGMVolume", (BGMMute.isOn) ? -80 : BGMSlider.value);
        VolumeSaver.GetComponent<VolumeSaver>().BGMMute = BGMMute.isOn;
    }
    public void ClickSEMute(){
        Audio_Mixer.SetFloat("SEVolume", (SEMute.isOn) ? -80 : SESlider.value);
        VolumeSaver.GetComponent<VolumeSaver>().SEMute = SEMute.isOn;
    }
}
