﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void StartButton ()
    {
        SceneManager.LoadScene("Level1");
		
	}
	
	// Update is called once per frame
	public void QuitBUtton ()
    {
        Application.Quit();
        
	}
}
