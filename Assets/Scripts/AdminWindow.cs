using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void AddBook()
    {
        Application.LoadLevel("AddBook");
    }
    public void DeleteBook()
    {
        Application.LoadLevel("DeleteBook");
    }
    public void DeleteMember()
    {
        Application.LoadLevel("DeleteMember");
    }
    public void AddMember()
    {
        Application.LoadLevel("AddMember");
    }
    public void UpdateBook()
    {
        Application.LoadLevel("UpdateBook");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
