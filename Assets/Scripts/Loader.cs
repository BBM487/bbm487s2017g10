using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public GameObject manager;          //GameManager prefab to instantiate.


	void Awake ()
	{
		//Check if a Manager has already been assigned to static variable Manager.instance or if it's still null
		if (Manager.instance == null)

			//Instantiate gameManager prefab
			Instantiate(manager);

	}
}
