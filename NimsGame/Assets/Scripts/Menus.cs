using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

	public GameObject pause;
    public GameObject options;
	private bool paused = false;

    public GameObject gameOver;
    public PjController pj1;
    public Pj2Controller pj2;


    void Start(){
		pause.SetActive (false);
        options.SetActive(false);
        gameOver.SetActive(false);
    }

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}	
		if (paused) {
			pause.SetActive (true);
            Time.timeScale = 0;
		}
		if (!paused) {
            pause.SetActive (false);
            Time.timeScale = 1;
		}

        if((pj1.isDead==true) || (pj2.isDead==true) || (pj1.lives == 0) || (pj2.lives == 0))
        {
            gameOver.SetActive(true);
        }
	}

	public void Continue (){
		paused = false;
		pause.SetActive (false);
		Time.timeScale = 1;

	}

	public void Menu(){
		SceneManager.LoadScene ("Inicio");
		paused = false;
	}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Options()
    {
        pause.SetActive(false);
        options.SetActive(true);
    }

    public void Back()
    {
        options.SetActive(false);
        pause.SetActive(true);
    }

    public void Quit(){
		Application.Quit ();
	}
}
