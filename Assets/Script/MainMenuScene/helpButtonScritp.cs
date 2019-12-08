using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class helpButtonScritp : MonoBehaviour {

    public Button HButton;


    // Use this for initialization
    void Start()
    {

        HButton.GetComponent<Button>();

        HButton.onClick.AddListener(helpScreen);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void helpScreen()
    {


        SceneManager.LoadScene("help");
       // Debug.Log("help");

    }
}