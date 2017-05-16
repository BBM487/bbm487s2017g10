using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System;

public class BorrowBook : MonoBehaviour {
    public Text ID;
    public Text Name;
	// Use this for initialization
	void Start () { 

    }
	public void BarrowBook()
    {
        ConnectDB database = new ConnectDB();
        database.Start();
        int bookID;
        if(ID.text.Length==0)
        {
            if(Name.text.Length == 0)
            {
                //warning message
                return;
            }
            else
            {
                bookID = database.SearchBookWithName(Name.text);
            }
        }
        else
        {
            bookID = database.SearchBookWithID(ID.text);
        }
        try
        {
            database.InsertBarrowBook(bookID);
        }
        catch(Exception e)
        {
                
        }
        database.End();

    }
	// Update is called once per frame
	void Update () {
		
	}
}
