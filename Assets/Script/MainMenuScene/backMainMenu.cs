using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backMainMenu : MonoBehaviour {

    public Button backButton;

    // Use this for initialization
    void Start () {
        backButton.onClick.AddListener(backButtonPressed);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void backButtonPressed() {
        SceneManager.LoadScene("mainMenu");

    }
}
