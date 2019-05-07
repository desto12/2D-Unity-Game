using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_skeleton : Enemy, IDamageInterface
{
    [SerializeField]
    public int Health { get; set; }
    [SerializeField]
    public int Diamonds { get; set; }
    [SerializeField]

    public override void Init()
    {
        base.Init();
        Health = base.health;
        Diamonds = base.gems;
    }

    public void Damage()
    {
        animator.SetTrigger("Hit");
        animator.SetBool("Fight", true);
        Health =- player.Dmg;


        if (Health < 1)
        {
            Vector3 pozycja;
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.enabled = false;
            animator.SetBool("Fight", false);
            animator.SetTrigger("Death");
            dead = true;
            AnimatorClipInfo[] clip = animator.GetCurrentAnimatorClipInfo(0);
            pozycja = transform.position;
            Destroy(this.gameObject, clip.Length);
            //dropping diamonds
            for (int i = 0; i < Diamonds; i++)
            {
                pozycja = new Vector3(pozycja.x + 1f, 2.0f, pozycja.z);
                Instantiate(diamond, pozycja, Quaternion.identity);
            }
        }

    }

    public override void Movement()
    {
        float distance = Mathf.Abs(transform.localPosition.x - player.transform.localPosition.x); //distance only in x axis
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        //following
        if (distance < 5.0f )
        {
            animator.SetTrigger("Run");
            Vector3 follow = new Vector3(player.transform.localPosition.x, transform.position.y, transform.position.z); //following only in x axis
            transform.position = Vector3.MoveTowards(transform.position, follow, speed * Time.deltaTime);
            if (distance < 1.0f)
                animator.SetBool("Fight", true);
            if (distance > 1.0f)
            {
                animator.SetBool("Fight", false);
            }
        }
        else
        {
            animator.SetTrigger("Idle");
            animator.SetBool("Fight", false);
        }

        //flipping sprite
        if (direction.x > 0 )
        {
            sprite.flipX = false;
        }
        if (direction.x < 0 )
        {
            sprite.flipX = true;
        }
    }

}
