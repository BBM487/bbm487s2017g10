using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CreateAccount : MonoBehaviour {

	private string[] lines;

	public Text name;
	public Text surname;
	public Text email;
	public Text phone;
	public Text password;
	public Text repassword;

	void Start(){
		lines = Manager.instance.users.text.Split ('\n');
	}

	public void createAccount(){
        ConnectDB database = new ConnectDB();
        database.Start();

        if(name.text.Length == 0)
        {
            //EditorUtility.DisplayDialog("Warning", "Member name can not be empty", "cancel", "");
            return;
        }
        else if(surname.text.Length == 0)
        {
            //EditorUtility.DisplayDialog("Warning", "Member surname can not be empty", "cancel", "");
            return;
        }
        else if(email.text.Length == 0)
        {
            //EditorUtility.DisplayDialog("Warning", "Member E-mail can not be empty", "cancel", "");
            return;
        }
        else if(phone.text.Length == 0)
        {
            //EditorUtility.DisplayDialog("Warning", "Member phone can not be empty", "cancel", "");
            return;
        }
        else if(password.text.Length == 0 && repassword.text.Length == 0)
        {
            //EditorUtility.DisplayDialog("Warning", "Member password and re-password can not be empty", "cancel", "");
            return;
        }
        else
        {
            if(password.text == repassword.text)
            {
                    database.InsertMemberDB_ByUser(name.text, surname.text, email.text, password.text, phone.text);  
            }
            else
            {
                //EditorUtility.DisplayDialog("Warning", "Passwords are not matching", "cancel", "");
                return;
            }
        }
        /*string path = "Assets/Database/Users.txt";

		StreamWriter writer = new StreamWriter (path, true);*/
	
		/*for (int i = 1; i <= lines.Length; i++) {
			string split1 = lines [i].Split (' ') [0].ToString ();
			if (email.text == split1) {
				Debug.Log ("Email already signed in");
			} 

			else if (email.text != split1) {
				if (password.text == repassword.text) {
					writer.WriteLine (email.text + " " + password.text + " MEMBER " + name.text + " " + surname.text + " " + phone.text);
				} 
				else if (password.text != repassword.text) {
					Debug.Log ("Passwords are not matching");
				}
			}
		}*/

		//writer.Close ();

		//Object asset = Resources.Load ("Users");
        database.End();
	}
}
