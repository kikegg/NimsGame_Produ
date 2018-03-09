using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAction : MonoBehaviour {

    public Rigidbody2D rBox;
    public FixedJoint2D fJointBox;

	// Use this for initialization
	void Start () {
        rBox = GetComponent<Rigidbody2D>();
        fJointBox = GetComponent<FixedJoint2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
