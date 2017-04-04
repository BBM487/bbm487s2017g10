using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Login(){
		Application.LoadLevel ("Login");
	}

	public void CreateAccount(){
		Application.LoadLevel ("AdminWindow");
	}

	public void SearchBook(){
		Application.LoadLevel ("SearchBook");
	}
}
