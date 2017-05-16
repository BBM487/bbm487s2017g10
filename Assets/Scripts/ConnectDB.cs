using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
//using System.Data.SQLite;

public class ConnectDB {
    string dbName = "Assets/Database/ProjectDB.db";
    SqliteConnection dbconn;
    String query , query2;

    // Use this for initialization
    public void Start () {
        
        dbconn = new SqliteConnection("Data Source=" + dbName +";");
        dbconn.Open();

    }
    public void InsertBookDB(String bookName , String shelfOfTheBook , String PublisherOfTheBook , String AuthorOfTheBook)
    {
        query = "Insert into Books(Name , Shelf , Publisher , Author) values ('" + bookName + "','" +
            shelfOfTheBook + "','" + PublisherOfTheBook + "','" + AuthorOfTheBook + "');";
        SqliteCommand command = new SqliteCommand(query , dbconn);
        command.ExecuteNonQuery();
    }
    public void DeleteBookDBwithID(string ID)
    {
        query = "Delete from Books where ID = " + ID + ";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        if(command.ExecuteNonQuery()==1)
        {
            //EditorUtility.DisplayDialog("Warning", "Book successfully deleted", "cancel", "");
            return;
        }
        else
        {
            //EditorUtility.DisplayDialog("Warning", "Book not found", "cancel", "");
            return;
        }
    }
    public void DeleteBookDBwitName(string Name)
    {
        query = "Delete from Books where Name = '" + Name + "';";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        if(command.ExecuteNonQuery()==1)
        {
            //EditorUtility.DisplayDialog("Warning", "Book successfully deleted", "cancel", "");
            return;
        }
        else
        {
            //EditorUtility.DisplayDialog("Warning", "Book not found", "cancel", "");
            return;
        }
        
    }
    public int SearchBookWithID(String ID)
    {
        SqliteDataReader reader;
        query = "Select * from Books where ID =" + ID + ";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        reader = command.ExecuteReader();
        reader.Read();
        return reader.GetInt32(0);
    }
    public Books UpdateBook(String ID)
    {
        Books book = new Books();
        SqliteDataReader reader;
        query = "Select * from Books where ID =" + ID + ";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        reader = command.ExecuteReader();
        reader.Read();
        book.bookName = reader.GetString(1);
        book.shelfBook = reader.GetString(2);
        book.publisherBook = reader.GetString(3);
        book.authorBook = reader.GetString(4);
        return book;
    }
    public int SearchBookWithName(String name)
    {
        SqliteDataReader reader;
        query = "Select * from Books where Name = '" + name + "';";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        reader = command.ExecuteReader();
        reader.Read();
        return reader.GetInt32(0);
    }
    public void InsertMemberDB_ByUser(String Name , String Surname , String Mail , String Password , String PhoneNumber)
    {
        try
        {
            query = "Insert into Members (Username , Password , MemberType , Name , Surname , Phone) values ('" + Mail + "','" +
                Password + "','MEMBER','" + Name + "','" + Surname + "','" + PhoneNumber + "');";
            SqliteCommand command = new SqliteCommand(query, dbconn);
            command.ExecuteNonQuery();
        }
        catch(Exception e)
        {
           // EditorUtility.DisplayDialog("Warning", "Email already signed in", "cancel", "");
            return;
        }
    }
    public void InsertMemberDB_ByAdmin(String Name, String Surname, String Mail, String Password, String PhoneNumber , String Type)
    {
        try
        {
            query = "Insert into Members (Username , Password , MemberType , Name , Surname , Phone) values ('" + Mail + "','" +
                Password + "','" + Type + "','" + Name + "','" + Surname + "','" + PhoneNumber + "');";
            SqliteCommand command = new SqliteCommand(query, dbconn);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            //EditorUtility.DisplayDialog("Warning", "Email already signed in", "cancel", "");
            return;
        }
    }
    public void DeleteMember(String Username)
    {
        query = "Delete from Members where Username = '" + Username + "';";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        if(command.ExecuteNonQuery()==1)
        {
            //EditorUtility.DisplayDialog("Warning", "Member successfully deleted", "cancel", "");
            return;
        }
        else
        {
            //EditorUtility.DisplayDialog("Warning", "Member not found", "cancel", "");
            return;
        } 
    }
    public String Validate(String Username , String Password)
    {
        String result = null;
        SqliteDataReader reader;
        String query = "select * from " +
            "(select * from Members where Username = '" + Username + "') subQue " +
            "where password = '" + Password + "';";
        SqliteCommand command = new SqliteCommand(query , dbconn);
        reader = command.ExecuteReader();
        reader.Read();
        if(reader.GetString(2)=="ADMIN")
        {
            return "ADMIN";
        }
        else if(reader.GetString(2)=="MEMBER")
        {
            return "MEMBER";
        }
        return null;
    }
    public void UpdateLogin(String username)
    {
        query = "UPDATE Members SET Login=1 WHERE Username = '" + username + "'";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        command.ExecuteNonQuery();
    }
    public void UpdateLogout()
    {
        query = "UPDATE Members SET Login=0 WHERE Login=1";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        command.ExecuteNonQuery();
    }
    public void InsertBarrowBook(int ID)
    {
        String username;
        SqliteDataReader reader;
        query = "Select * from Members where Login =" + 1 + ";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        reader = command.ExecuteReader();
        reader.Read();
        username = reader.GetString(0);
        query2 = "Insert into BorrowBooks (ID , Username) values (" + ID + ",'"
            + username + "');";
        SqliteCommand command2 = new SqliteCommand(query2, dbconn);
        command2.ExecuteNonQuery();
    }
    public void updateBookName(String bookID , String nBookName)
    {
        query = "Update Books set Name ='"+nBookName+"' where ID=" + bookID +";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        command.ExecuteNonQuery();
    }
    public void updateBookShelf(String bookID, String nBookShelf)
    {
        query = "Update Books set Shelf ='" + nBookShelf + "' where ID=" + bookID +";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        command.ExecuteNonQuery();
    }
    public void updateBookPublisher(String bookID, String nBookPublisher)
    {
        query = "Update Books set Publisher ='" + nBookPublisher + "' where ID=" + bookID +";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        command.ExecuteNonQuery();
    }
    public void updateBookAuthor(String bookID, String nBookAuthor)
    {
        query = "Update Books set Author ='" + nBookAuthor + "' where ID=" + bookID +";";
        SqliteCommand command = new SqliteCommand(query, dbconn);
        command.ExecuteNonQuery();
    }


    // Update is called once per frame
    public void End () {
        dbconn.Close();
        dbconn = null;
    }
}
