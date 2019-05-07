using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shop : MonoBehaviour {

    public GameObject shop;
    private int addCost;
    public Player player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gracz")
        {
            player = collision.GetComponent<Player>();
            UIManager.Instance.OpenShop(player.diamonds);
            shop.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.tag == "gracz")
        {
            shop.SetActive(false);
        }
    }
    public void BuyDamage()
    {
        addCost = 10;
        if (player.diamonds >= addCost )
        {
            player.diamonds -= addCost;
            player.Dmg += 1;
            Debug.Log("kupilismy damage");
            shop.SetActive(false);
        }
        else
        {
            Debug.Log("za mało kaski");
            shop.SetActive(false);
        }


    }
    public void BuyHp()
    {
        addCost = 10;
        if (player.diamonds >= addCost)
        {
            player.diamonds -= addCost;
            player.Health = 4;
            player.Health += 1;
            StaticSave.Dmg = player.Dmg;
            StaticSave.Health = player.Health;
            Debug.Log("kupilismy hp");
            shop.SetActive(false);
        }
        else
        {
            Debug.Log("za mało kaski");
            shop.SetActive(false);
        }
    }
}
