using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_giant : Enemy, IDamageInterface
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
        hited = true;
        animator.SetTrigger("Hit");
        Health -= player.Dmg;
        animator.SetBool("Fight", true);

        if (Health<1)
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
}
