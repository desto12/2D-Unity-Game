using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public GameObject diamond;


    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform A, B;//two poinsts beetwen the enemy will be moving 
    protected bool changeSide = false;
    protected Animator animator;
    protected SpriteRenderer sprite;
    protected bool hited = false;
    protected Player player;
    protected bool side;
    protected bool dead = false;

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("gracz").GetComponent<Player>();
    }
    private void Start()
    {
        Init();
    }

    public virtual void FixedUpdate()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("idle") && animator.GetBool("Fight") == false)
        {
            return;
        }
        if (dead == false)
            Movement();

    }

    public virtual void Movement()
    {

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        

        if (transform.position == B.position)
        {
            animator.SetTrigger("Idle");
            changeSide = true;
            sprite.flipX = true;
            side = changeSide;



        }
        if (transform.position == A.position)
        {
            animator.SetTrigger("Idle");
            changeSide = false;
            sprite.flipX = false;
            side = changeSide;


        }

        if (changeSide == false)
        {
            if(hited == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, B.position, speed * Time.deltaTime);
            }
        }
            
        else if (changeSide == true)
        {
            if (hited == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, A.position, speed * Time.deltaTime);
            }

        }


        if (direction.x > 0 && animator.GetBool("Fight") == true)
        {
            sprite.flipX = false;
        }
        if (direction.x < 0 && animator.GetBool("Fight") == true)
        {
            sprite.flipX = true;
        }

        if (distance > 5.0f )
        {
            hited = false;
            animator.SetBool("Fight", false);
            sprite.flipX = side;

        }

    }

}
