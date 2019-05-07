using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour {

    private Enemy_spider spider;
    public void Start()
    {
        spider = transform.parent.GetComponent<Enemy_spider>();
    }

    public void Fire()
    {
        spider.Attack();
        Debug.Log("Spider atakuje");
    }
}
