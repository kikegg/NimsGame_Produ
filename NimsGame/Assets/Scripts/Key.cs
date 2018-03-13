using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public GameObject sprite;
    public GameObject jail;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player2")
        {
            sprite.SetActive(true);
            Destroy(this.gameObject);
            jail.GetComponent<Jail>().count += 1;
        }
    }
}
