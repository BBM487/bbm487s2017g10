﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour {

	public static Manager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	public TextAsset users;
	public TextAsset books;
	public TextAsset barrowedBooks;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

}
