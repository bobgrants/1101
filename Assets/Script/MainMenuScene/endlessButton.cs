using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class endlessButton : MonoBehaviour {

    public Button endlessBtn;
    string levelType;

    // Use this for initialization
    void Start()
    {
        levelType = "";
        endlessBtn.GetComponent<Button>();

        endlessBtn.onClick.AddListener(playEndless);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void playEndless() {

        PlayerPrefs.SetString(levelType, "endless");
        SceneManager.LoadScene("endless");
        //Debug.Log("Starting Endless");

    }
}
