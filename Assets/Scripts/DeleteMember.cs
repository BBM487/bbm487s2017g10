using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DeleteMember : MonoBehaviour {
    public Text username;

    public string tempPath = "Assets/Database/tempUsers.txt";
    public string path = "Assets/Database/Users.txt";

    public string line = null;
    public int foundedItem;
    public int deletedItem;

    // Use this for initialization
    void Start () {
		
	}
    public void deleteMember()
    {
        foundedItem = 0;
        deletedItem = 0;
        ConnectDB database = new ConnectDB();
        database.Start();

        if (username.text.Length == 0)
        {
            //EditorUtility.DisplayDialog("Warning", "E-mail can not be empty", "cancel", "");
            return;
        }
        database.DeleteMember(username.text);
        database.End();

        /*FileStream file = new FileStream(tempPath, FileMode.Truncate, FileAccess.Write);
        StreamReader reader = new StreamReader(path);
        StreamWriter writer = new StreamWriter(file);
        while ((line = reader.ReadLine()) != null)
        {
            if (deletedItem == 0)
            {
                string[] splitLine = line.Split(' ');
                if (string.Compare(username.text, splitLine[0]) == 0)
                {
                    foundedItem = 1;
                    deletedItem = 1;
                    continue;
                }
            }

            writer.WriteLine(line);
        }
        writer.Flush();
        writer.Close();
        reader.Close();
        file.Close();

        file = new FileStream(path, FileMode.Truncate, FileAccess.Write);
        reader = new StreamReader(tempPath);
        writer = new StreamWriter(file);
        while ((line = reader.ReadLine()) != null)
        {
            writer.WriteLine(line);
        }
        writer.Flush();
        writer.Close();
        reader.Close();
        file.Close();

        if (foundedItem == 0)
        {
            //EditorUtility.DisplayDialog("Warning", "Username not found", "cancel", "");
        }*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
