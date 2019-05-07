﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spider : Enemy, IDamageInterface {
    public GameObject acidPrefab;
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
        Health -= player.Dmg;

        if (Health < 1)
        {
            Vector3 pozycja;
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.enabled = false;
            animator.SetTrigger("Death");
            dead = true;
            AnimatorClipInfo[] clip = animator.GetCurrentAnimatorClipInfo(0);
            pozycja = transform.position;
            Destroy(this.gameObject, clip.Length);
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
        if (distance < 7.0f )
        {
            animator.SetBool("Fight", true);
        }
        else
        {
            animator.SetTrigger("Run");
            animator.SetBool("Fight", false);
            Vector3 follow = new Vector3(player.transform.localPosition.x, transform.position.y, transform.position.z); //following only in x axis
            transform.position = Vector3.MoveTowards(transform.position, follow, speed * Time.deltaTime);

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


    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }

}
