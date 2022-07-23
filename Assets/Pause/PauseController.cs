using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    bool re;
    Canvas pauseUI;
    bool pausing;
    GameObject BGM;
    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("BGM");
        pauseUI = GameObject.Find("Pause").GetComponent<Canvas>();
        pausing = false;
        pauseUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int s = SceneManager.GetActiveScene().buildIndex;
        if((!re && Input.GetKeyDown(KeyCode.P))){
            if(s == 1 || s == 2){
                re = GameObject.Find("player").GetComponent<player2D>().returning;
                if(!re){
                    if(pausing){
                        HidePauseUI();
                    }
                    else{
                        ShowPauseUI();
                    }
                }
            }
        }

    }

    public void ShowPauseUI(){
        Time.timeScale = 0;
        pauseUI.enabled = true;
        pausing = true;
    }

    public void HidePauseUI(){
        pauseUI = GameObject.Find("Pause").GetComponent<Canvas>();
        Time.timeScale = 1;
        pauseUI.enabled = false;
        pausing = false;
    }

    public void RestartGame(){
        Time.timeScale = 1;
        GameObject.Find("BGM").GetComponent<Event>().CurSavepoint = 0;
        GameObject.Find("BGM").GetComponent<Event>().Stars = 0;
        GameObject.Find("BGM").GetComponent<Event>().star = new int[4];
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        BGM.GetComponent<Event>().Menu();
        BGM.GetComponent<BGMController>().BackToMenu();
    }
}
