using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj2Controller : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    Animator anim;

    //JumpVariables
    public bool grounded;
    public float jumpHeight;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundMask;
    public float jumpPushForce = 10f;

    public bool facingRight;

    //Lives&GameOver
    public bool isDead=false;
    public int lives;
    public GameObject[] p2Hearts;
    public AudioSource hurtSound;
    public GameObject gameOver;
    public AudioSource gameOverS;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isDead = false;

    }

    void FixedUpdate()
    {

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

    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask);

        anim.SetBool("Grounded", grounded);

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (transform.localScale.x == 1)
            facingRight = true;
        else
            facingRight = false;

        if (lives <= 0)
        {
            //animación muerte personaje
            gameOver.SetActive(true);
            this.gameObject.SetActive(false);
            gameOverS.Play();
        }
    }

    public void HurtPlayer()
    {
        lives -= 1;
        for (int i = 0; i < p2Hearts.Length; i++)
        {
            if (lives > i)
            {
                p2Hearts[i].SetActive(true);
            }
            else
            {
                p2Hearts[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }

    void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.transform.tag == "Move")
        {

            transform.parent = obj.transform.gameObject.transform.parent;
        }
    }
}
