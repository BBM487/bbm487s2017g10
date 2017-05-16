using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System;

public class LoginLogout : MonoBehaviour {

	public Text wrong;
	string[] lines;
	public Text email;
	public Text password;

	//Start function is a speacial function using on Unity
	//and works once when the program start
	void Start () {
		//lines = Manager.instance.users.text.Split ('\n');
	}

	//Update function is speacial function on Unity
	//and works every frame(about 60 -90 times in a minute)
	void Update(){
	}

	//Validate function checks if the mail adress in the system 
	//and password is matching with that mail or not
	public void Validate(){
		//bool valid=false;
        String result = null;
        ConnectDB database = new ConnectDB();
        database.Start();
        try
        {
            result = database.Validate(email.text, password.text);
        }
        catch(Exception e)
        {
            wrong.gameObject.SetActive(true);
        }
        database.End();
        database.Start();
        if(result == "ADMIN")
        {
            Application.LoadLevel("AdminWindow");
        }
        else if(result == "MEMBER")
        {
            database.UpdateLogin(email.text);
            Application.LoadLevel("MemberWindow");
        }
        /*for (int i = 1; i < lines.Length; i++) {
			string split1 = lines [i].Split (' ') [0].ToString ();
			string split2 = lines [i].Split (' ') [1].ToString ();
			string split3 = split2.Substring (0,split2.Length-1);
			string split4 = lines [i].Split (' ') [2].ToString ();
			string split5 = split4.Substring (0,split2.Length-1);
			if (split1==email.text) {
				if (split2==password.text||split3==password.text) {
					if (split4 == "MEMBER" || split5 == "MEMBER") {
						Application.LoadLevel ("AddBook");
						valid = true;
						break;
					}

					else if (split4 == "ADMIN" || split5 == "ADMIN" ) {
						Application.LoadLevel ("AdminWindow");
						valid = true;
						break;
					}
				}
			}
		}
		if(valid==false)
		wrong.gameObject.SetActive (true);*/
        database.End();
    }
		
	public void Logout(){
        ConnectDB database = new ConnectDB();
        database.Start();
        database.UpdateLogout();
        database.End();
		Application.LoadLevel ("OpeningScene");
	
	}
}
