using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour {

    public PjController p1;
    public Pj2Controller p2;

	// Use this for initialization
	void Start () {
        p1.enabled = true;
        p2.enabled = false;     
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(p1.enabled== true)
            {
                p1.enabled = false;
                p2.enabled = true;
            }
            else
            {
                p1.enabled = true;
                p2.enabled = false;
            }
        }
	}
}
