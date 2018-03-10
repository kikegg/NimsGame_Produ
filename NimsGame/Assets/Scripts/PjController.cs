using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjController : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	Animator anim;

    //JumpVariables
    public bool grounded;
    bool touchingWall = false;
    public float jumpHeight;

	public Transform groundCheckPoint;
    public Transform wallCheck;
    public float groundCheckRadius;
    public float wallTouchRadius;
	public LayerMask groundMask;
    public LayerMask whatIsWall;
    public float jumpPushForce = 10f;


    //BlinkVariables
    public float blinkDistance;
    float blinkTimer;
    public float blinkTime = 1f;
    bool facingRight;
    public bool canBlink = true;

    //Suriken
    public GameObject suriken;
    public Transform throwPoint;
    float surikenTimer=1.5f;
    public float surikenWait;
    public float puedeLanzar=0;

    //Lives&GameOver
    public bool isDead=false;
    public int lives;
    public GameObject[] p1Hearts;
    public AudioSource hurtSound;
    public GameObject gameOver;
    public AudioSource gameOverS;



    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
        canBlink = true;
        isDead = false;
    }

	void FixedUpdate(){

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Moving", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }
        else if (Input.GetKeyDown(KeyCode.W) && touchingWall)
        {
            if (facingRight)
            {
                rb.velocity = new Vector2(-50, 18);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (!facingRight)
            {
                rb.velocity = new Vector2(50, 18);
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        //Shot
        if (Input.GetKeyDown(KeyCode.K) && (puedeLanzar >= surikenTimer))
        {
            anim.SetTrigger("Throw");
            surikenWait += Time.deltaTime;
            if (surikenWait >= 0.02f)
            {
                GameObject surikenClone = (GameObject)Instantiate(suriken, throwPoint.position, throwPoint.rotation);
                surikenClone.transform.localScale = transform.localScale;
            }
            puedeLanzar = 0;
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
    }

	// Update is called once per frame
	void Update () {

        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask);
        touchingWall = Physics2D.OverlapCircle(wallCheck.position, wallTouchRadius, whatIsWall);

        anim.SetBool("Grounded", grounded);

        rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y);

        if (transform.localScale.x == 1)
            facingRight = true;
        else
            facingRight = false;

        puedeLanzar += Time.deltaTime;
        surikenWait = 0;

        if (lives <= 0)
        {   
            //animación muerte personaje
            gameOver.SetActive(true);
            this.gameObject.SetActive(false);
            gameOverS.Play();
        }

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

    public void HurtPlayer()
    {
        lives -= 1;
        for (int i = 0; i < p1Hearts.Length; i++)
        {
            if (lives > i)
            {
                p1Hearts[i].SetActive(true);
            }
            else
            {
                p1Hearts[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }

}