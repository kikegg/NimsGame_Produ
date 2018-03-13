using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public float health = 100f;

    public Transform target1;
    public Transform target2;

    public float engaugeDistance = 10f;

    public float attackDistance = 3f;

    public float moveSpeed = 5f;

    private bool facingLeft = true;

    private Animator anim;

    public PjController pjController;

    public Pj2Controller pj2Controller;

    //public float attackDamage;

    //int i = 0;

    public bool canAttack = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("EnemyIdle", true);
        anim.SetBool("EnemyAttacking", false);
        anim.SetBool("EnemyWalking", false);

        //Target1 ------> Enemy


        if ((Vector3.Distance(target1.position, this.transform.position) < engaugeDistance) && (Vector3.Distance(target1.position, this.transform.position) < Vector3.Distance(target2.position, this.transform.position)))
        {
            anim.SetBool("EnemyIdle", false);
            //coge la direccion del objetivo(target)
            Vector3 direction = target1.position - this.transform.position;
            if (Math.Sign(direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if (Math.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }

            //Si es mayor o igual a la distancia de ataque, se mueve en la direccion quehemos cogido antes
            if (direction.magnitude >= attackDistance)
            {
                anim.SetBool("EnemyWalking", true);
                Debug.DrawLine(target1.transform.position, this.transform.position, Color.yellow);
                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
                }
                else if (!facingLeft)
                {
                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
                }
            }
            if (direction.magnitude < attackDistance)
            {
                if (canAttack == true)
                {
                    Debug.DrawLine(target1.transform.position, this.transform.position, Color.red);
                    anim.SetBool("EnemyAttacking", true);
                    StartCoroutine(Delay());
                    pjController.HurtPlayer();
                }
            }

        }
        //Cuando no esta dentro de la distancia de ataque
        else if (Vector3.Distance(target1.position, this.transform.position) > engaugeDistance)
        {
            Debug.DrawLine(target1.position, this.transform.position, Color.green);
        }


        //Target2 ------> Enemy


        if ((Vector3.Distance(target2.position, this.transform.position) < engaugeDistance) && (Vector3.Distance(target2.position, this.transform.position) < Vector3.Distance(target1.position, this.transform.position)))
        {
            anim.SetBool("EnemyIdle", false);
            //coge la direccion del objetivo(target)
            Vector3 direction = target2.position - this.transform.position;
            if (Math.Sign(direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if (Math.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }
            //Si es mayor o igual a la distancia de ataque, se mueve en la direccion quehemos cogido antes
            if (direction.magnitude >= attackDistance)
            {
                anim.SetBool("EnemyWalking", true);
                Debug.DrawLine(target2.transform.position, this.transform.position, Color.yellow);
                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
                }
                else if (!facingLeft)
                {
                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
                }
            }
            if (direction.magnitude < attackDistance)
            {
                Debug.DrawLine(target2.transform.position, this.transform.position, Color.red);
                anim.SetBool("EnemyAttacking", true);
                //pj2Controller.HurtPlayer();
            }

        }
        //Cuando no esta dentro de la distancia de ataque
        else if (Vector3.Distance(target2.position, this.transform.position) > engaugeDistance)
        {
            Debug.DrawLine(target2.position, this.transform.position, Color.green);
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    IEnumerator Delay()
    {
        canAttack = false;
        
        yield return new WaitForSecondsRealtime(2f);
        canAttack = true;
    }
}