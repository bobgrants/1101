using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour {

    public Button replayBtn;
    string levelType;

    // Use this for initialization
    void Start () {

        replayBtn.GetComponent<Button>();

        replayBtn.onClick.AddListener(restart);

        levelType = PlayerPrefs.GetString(levelType);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void restart() {

        if (levelType == "endless")
        {
            SceneManager.LoadScene("endless");
        }
       
        else if (levelType == "level")
        {
            SceneManager.LoadScene("ascii_1");
        }

        
        //Debug.Log("RESTARTING");

    }
}
