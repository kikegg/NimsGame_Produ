using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suriken : MonoBehaviour {
    public float surikenSpeed;
    private Rigidbody2D theRB;
    public AudioSource surikenSound;
    public GameObject isOn;

    //public GameObject surikenEffect;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(surikenSpeed * transform.localScale.x, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Animator>().SetTrigger("isDead");
            other.gameObject.GetComponent<EnemyController>().enabled = false;
            other.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Destroy(gameObject);
        }
        else if (!(other.gameObject.tag == "Player"))
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Btn1" || other.gameObject.tag == "Btn2" || other.gameObject.tag == "Btn3" || other.gameObject.tag == "Btn4")
        {
            other.gameObject.GetComponent<SpriteRenderer>().sprite = isOn.GetComponent<SpriteRenderer>().sprite;
            if(other.gameObject.tag == "Btn1")
            {
                Vector3 newPos = new Vector3(0, 0, 7.912f);
                other.gameObject.transform.GetChild(0).gameObject.transform.eulerAngles = newPos;
            }
            if (other.gameObject.tag == "Btn2")
            {
                other.gameObject.transform.GetChild(0).gameObject.GetComponent<PlatformMove>().enabled=true;
            }
            if (other.gameObject.tag == "Btn3")
            {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (other.gameObject.tag == "Btn4")
            {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        
        surikenSound.Play();
    }
}

