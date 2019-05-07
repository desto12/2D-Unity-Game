using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_system : MonoBehaviour {
    public int gems = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "gracz" )//zbieranie diamentow
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.AddGems(gems);
                Destroy(this.gameObject);
            }
        }
    }
}
