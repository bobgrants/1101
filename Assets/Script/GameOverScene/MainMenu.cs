using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button MainMenuBtn;

    // Use this for initialization
    void Start () {

        MainMenuBtn.GetComponent<Button>();

        MainMenuBtn.onClick.AddListener(MMenu);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MMenu() {

        SceneManager.LoadScene("mainMenu");
        Debug.Log("RESTARTING");

    }
}
