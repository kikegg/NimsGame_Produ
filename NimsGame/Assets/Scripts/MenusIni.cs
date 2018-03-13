using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusIni : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject optionsMenu;

    // Use this for initialization
    void Start () {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
