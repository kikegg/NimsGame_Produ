using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour {
    public int count;
    public GameObject txt;
    public GameObject sprite;
    public GameObject gm;

    private void Start()
    {
        count = 0;
        txt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (count == 2)
            {
                sprite.SetActive(false);
                Destroy(this.gameObject);
                gm.GetComponent<CharacterSwitch>().enabled = true;
            }
            else
            {
                txt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            txt.SetActive(false);
        }
    }
}
