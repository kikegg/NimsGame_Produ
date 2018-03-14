using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject isOn;
    public AudioSource button;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player" || other.gameObject.tag == "Player2")
        {   if (!(this.gameObject.transform.parent.gameObject.GetComponentInParent<PlatformMove>().enabled == true))
            {
                button.Play();
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = isOn.GetComponent<SpriteRenderer>().sprite;
            this.gameObject.transform.parent.gameObject.GetComponentInParent<PlatformMove>().enabled = true;
           
        }
    }
}
