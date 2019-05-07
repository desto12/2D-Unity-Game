using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool resetDamage = true;


    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageInterface hit = other.GetComponent<IDamageInterface>();


        if (other.tag != transform.parent.parent.tag)
        {
            if (hit != null)
            {
                if(resetDamage == true)
                {
                    hit.Damage();
                    resetDamage = false;
                    StartCoroutine(ResetDamage());
                }

            }
        }

    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        resetDamage = true;
    }

}
