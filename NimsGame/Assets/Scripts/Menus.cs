using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

	public GameObject pause;
    public GameObject options;
	private bool paused = false;

	void Start(){
		pause.SetActive (false);
        options.SetActive(false);
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
