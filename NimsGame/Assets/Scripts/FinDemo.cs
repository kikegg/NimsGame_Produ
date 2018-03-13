using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinDemo : MonoBehaviour {

    public GameObject sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || (collision.gameObject.tag == "Player2"))
        {
            sprite.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
