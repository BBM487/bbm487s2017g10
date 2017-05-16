using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class AddBook : MonoBehaviour {

	private string[] lines;

	public string path = "Assets/Database/books.txt";

	public Text bookName;
	public Text bookId;
	public Text shelfNoOfTheBook;
	public Text publisherOfTheBook;
	public Text AuthorOfTheBook;


    public void addBook() {
        ConnectDB database = new ConnectDB();
        database.Start();
        if (bookName.text.Length == 0)
        {
            return;
        }
        else if (bookId.text.Length == 0)
        {
            return;
        }
        else if (shelfNoOfTheBook.text.Length == 0)
        {
            return;
        }
        else if (publisherOfTheBook.text.Length == 0)
        {
            return;
        }
        else if (AuthorOfTheBook.text.Length == 0)
        {
            return;
        }
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(bookName.text + " " + bookId.text + " " + shelfNoOfTheBook.text + " " + publisherOfTheBook.text + " " + AuthorOfTheBook.text);

        try
        {
            database.InsertBookDB(bookName.text, shelfNoOfTheBook.text, publisherOfTheBook.text, AuthorOfTheBook.text);
        }
        catch(Exception e)
        {
            database.End();
        }
        database.End();

        writer.Flush();
		writer.Close();
	}
		
}
