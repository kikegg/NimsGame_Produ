using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinLvl : MonoBehaviour {

    public GameObject sprite;
    bool both;
    bool pj1In;
    bool pj2In;

    private void Start()
    {
        both = false;
        pj1In = false;
        pj2In = false;
    }

    private void Update()
    {
        if (pj1In && pj2In)
            both = true;

        if (both == true)
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            pj1In = true;
            sprite.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player2")
        {
            pj2In = true;
            sprite.SetActive(true);
        }
    }
}
