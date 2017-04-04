using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Login : MonoBehaviour {
	public TextAsset users;
	public Text wrong;
	string[] lines;
	public Text email;
	public Text password;
	// Use this for initialization
	void Start () {
		lines = users.text.Split ('\n');
	}

	public void validate(){
		bool valid=false;
		for (int i = 1; i < lines.Length; i++) {
			string split1 = lines [i].Split (' ') [0].ToString ();
			string split2 = lines [i].Split (' ') [1].ToString ();
			string split3 = split2.Substring (0,split2.Length-1);
			if (split1==email.text) {
				if (split2==password.text||split3==password.text) {
					Application.LoadLevel ("AddBook");
					valid = true;
					break;
				}
			}
		}
		if(valid==false)
		wrong.gameObject.SetActive (true);
	}
		
}
