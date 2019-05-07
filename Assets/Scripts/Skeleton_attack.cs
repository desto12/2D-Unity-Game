using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_attack : MonoBehaviour {

    private bool resetDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageInterface hit = other.GetComponent<IDamageInterface>();
        float distance = Vector3.Distance(transform.parent.localPosition, other.transform.localPosition);
        if (other.tag != transform.parent.parent.tag && resetDamage == true )
        {
            if (distance < 1f && hit != null)
            {
                hit.Damage();
                resetDamage = false;
            }
        }

    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        resetDamage = true;
    }
}
