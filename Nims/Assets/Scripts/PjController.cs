using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjController : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	Animator anim;

    //JumpVariables
    public bool grounded;
	public float jumpHeight;

	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundMask;

    //BlinkVariables
    public float blinkDistance;
    float blinkTimer;
    public float blinkTime = 1f;
    bool facingRight;
    bool canBlink = true;


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
		}
        
        //Blink
        if (Input.GetKeyDown(KeyCode.J) && canBlink)
        {
            anim.SetBool("Blink", true);
            canBlink = false;
        }
        else
            anim.SetBool("Blink", false);

        if (!canBlink)
        {
            blinkTimer += Time.deltaTime;
        }

        if (blinkTimer > blinkTime)
        {

            canBlink = true;
            blinkTimer = 0;
        }


        if (transform.localScale.x == 1)
            facingRight = true;
        else
            facingRight = false;
    }

    void Blink()
    {
        Vector3 blink;
        if (facingRight)
            blink = new Vector3(blinkDistance, 0, 0);
        else
            blink = new Vector3(-blinkDistance, 0, 0);

        transform.position += blink;
    }
}