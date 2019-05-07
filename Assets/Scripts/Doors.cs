using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    public string poziom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gracz")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(poziom);
        }
    }
}
