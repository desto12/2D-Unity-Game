using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {

    // Use this for initialization
    Player player;
    Enemy_spider spider;

	void Start () {

        Destroy(this.gameObject, 5.0f);
        player = GameObject.FindGameObjectWithTag("gracz").GetComponent<Player>();
        spider = GameObject.FindGameObjectWithTag("spider").GetComponent<Enemy_spider>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        AcidMove();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "gracz")
        {
            IDamageInterface hit = collision.GetComponent<IDamageInterface>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }

    public void AcidMove()
    {
        Vector3 direction = player.transform.position - spider.transform.position;
        if(direction.x < 0)
            transform.Translate(Vector3.left* 3 * Time.deltaTime);
        if(direction.x > 0)
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }
}