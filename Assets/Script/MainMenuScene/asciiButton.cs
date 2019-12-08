using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class asciiButton : MonoBehaviour
{

    public Button LvlSeclectButton;
    string levelType;

    // Use this for initialization
    void Start()
    {
        levelType = "";
        LvlSeclectButton.GetComponent<Button>();

        LvlSeclectButton.onClick.AddListener(levelSelectSwitch);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void levelSelectSwitch()
    {
        PlayerPrefs.SetString(levelType, "level");
        SceneManager.LoadScene("levelSelect");
        Debug.Log("Switching to Level Select Scene");

    }
}
