using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator animator;
    public Animator swordAnimator;

    // Use this for initialization
    void Start()
    {

        animator = GetComponentInChildren<Animator>();
        swordAnimator = transform.GetChild(1).GetComponent<Animator>();

    }


    public void Move(float moveX)
    {
        animator.SetFloat("Move", Mathf.Abs(moveX));
    }

    public void Jump(bool jumping)
    {
        animator.SetBool("Jump", jumping);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
        swordAnimator.SetTrigger("swordAnim_1");
    }
    
    public void Death()
    {
        animator.SetTrigger("Dead");
    }
}