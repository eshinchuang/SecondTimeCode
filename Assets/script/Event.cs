using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public int CurSavepoint;
    public int Stars;
    public int[] star = new int[4];
    GameObject Vol;
    GameObject BGMController;
    // Start is called before the first frame update
    void Start()
    {
        BGMController = GameObject.Find("BGM");
        Vol = GameObject.Find("VolumeSaver");
        DontDestroyOnLoad(this.gameObject);
        CurSavepoint = 0;
        Stars = 0;
    }

    void Update()
    {
        
    }

    public void Level1(){
        string s = SceneManager.GetActiveScene().name;
        CurSavepoint = 0;
        Stars = 0;
        star = new int[4];
        SceneManager.LoadScene("level1");
        BGMController.GetComponent<BGMController>().ChangeBGM(s, "level1");
    }
    public void Level2(){
        string s = SceneManager.GetActiveScene().name;
        CurSavepoint = 0;
        Stars = 0;
        star = new int[4];
        SceneManager.LoadScene("level2");
        BGMController.GetComponent<BGMController>().ChangeBGM(s, "level2");
    }

    public void Goal(){
        SceneManager.LoadScene("win");
        
        //BGMController.GetComponent<BGMController>().ChangeBGM(s, "level2");
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
        Vol.GetComponent<DontDestory>().destroy();
        Destroy(this.gameObject);
    }
}
