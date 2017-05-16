using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpdateBookInformation : MonoBehaviour {
    public Text ID;
    public Text bookName;
    public Text shelfBook;
    public Text publisherBook;
    public Text authorBook;
	// Use this for initialization
	void Start () {
		
	}
    public void UpdateBook()
    {
        Books book;
        ConnectDB database = new ConnectDB();
        database.Start();
        book = database.UpdateBook(ID.text);
        if(bookName.text.Length != 0)
        {
            database.updateBookName(ID.text , bookName.text);
        }
        if (shelfBook.text.Length != 0)
        {
            database.updateBookShelf(ID.text, shelfBook.text);
        }
        if (publisherBook.text.Length != 0)
        {
            database.updateBookPublisher(ID.text, publisherBook.text);
        }
        if (authorBook.text.Length != 0)
        {
            database.updateBookAuthor(ID.text, authorBook.text);
        }
        database.End();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
