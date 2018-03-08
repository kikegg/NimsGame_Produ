using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour {

    public PjController p1;
    public Animator p1Anim;
    public Rigidbody2D p1Rigid;
    public Pj2Controller p2;
    public Animator p2Anim;
    public Rigidbody2D p2Rigid;

    // Use this for initialization
    void Start () {
        p1.enabled = true;
        p1Rigid.bodyType = RigidbodyType2D.Dynamic;
        p2.enabled = false;
        p2Rigid.bodyType = RigidbodyType2D.Static;
        p2Anim.SetBool("Grounded", true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(p1.enabled== true)
            {
                p1.enabled = false;
                p1Anim.SetBool("Moving", false);
                p1Rigid.bodyType = RigidbodyType2D.Static;
                p2.enabled = true;
                p2Rigid.bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                p1.enabled = true;
                p1Rigid.bodyType = RigidbodyType2D.Dynamic;
                p2.enabled = false;
                p2Anim.SetBool("Moving", false);
                p2Rigid.bodyType = RigidbodyType2D.Static;
            }
        }
	}
}
