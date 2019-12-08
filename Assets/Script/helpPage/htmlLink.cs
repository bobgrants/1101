using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class htmlLink : MonoBehaviour {

    public Button link;

	// Use this for initialization
	void Start () {
        link.onClick.AddListener(openBrowser);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void openBrowser() {
        Application.OpenURL("http://www.rapidtables.com/code/text/ascii-table.htm");


    }
}
