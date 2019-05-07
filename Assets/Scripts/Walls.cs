using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {
    BoxCollider2D walls;
	// Use this for initialization
	void Start () {
        walls = GetComponentInChildren<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindWithTag("enemy") == null)
        {
            walls.enabled = false;
        }
        else
        {
            walls.enabled = true;
        }

    }
}
