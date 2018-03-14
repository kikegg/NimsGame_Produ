using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2lvl2 : MonoBehaviour {

    public GameObject isOn;
    public AudioSource button;
    private Vector3 posPlat;
    private Vector3 posButton;

    // Use this for initialization
    void Start () {
        posPlat = new Vector3(0, -8.8f, 0);
        posButton = new Vector3(0,5.25f,0);
}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            if (!(this.gameObject.transform.parent.gameObject.transform.position == new Vector3(this.gameObject.transform.parent.gameObject.transform.position.x, posPlat.y, this.gameObject.transform.parent.gameObject.transform.position.z))) { 
                button.Play();
            }

            this.gameObject.GetComponent<SpriteRenderer>().sprite = isOn.GetComponent<SpriteRenderer>().sprite;
            this.gameObject.transform.parent.gameObject.transform.position = new Vector3(this.gameObject.transform.parent.gameObject.transform.position.x, posPlat.y, this.gameObject.transform.parent.gameObject.transform.position.z);
            this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, posButton.y, this.gameObject.transform.position.z);

        }
    }
}
