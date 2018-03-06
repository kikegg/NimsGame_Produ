using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjController : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	Animator anim;
	public bool grounded;
	public float jumpHeight;

	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundMask;

	public float timer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, groundMask);
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y);

		anim.SetBool ("Grounded", grounded);
		anim.SetFloat("VelY", rb.velocity.y);

		if (Input.GetKey (KeyCode.A)) {
			transform.localScale = new Vector3 (-1, 1, 1);
			anim.SetBool ("Moving", true);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.localScale = new Vector3 (1, 1, 1);
			anim.SetBool ("Moving", true);
		} else {
			anim.SetBool ("Moving", false);
		}

		if (Input.GetKey (KeyCode.W) && grounded) {
			rb.velocity = new Vector2 (0, jumpHeight);
			timer+=Time.deltaTime;
		}
	}
}