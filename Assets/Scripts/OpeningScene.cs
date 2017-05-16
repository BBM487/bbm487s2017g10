using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void Login(){
		Application.LoadLevel ("Login");
	}

	public void CreateAccount(){
		Application.LoadLevel ("CreateAccount");
	}

	public void SearchBook(){
		Application.LoadLevel ("SearchBook");
	}
}
