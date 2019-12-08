using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FTBtn : MonoBehaviour
{

    public Button FTButton;
    

    // Use this for initialization
    void Start()
    {

        FTButton.GetComponent<Button>();

        FTButton.onClick.AddListener(playEndless);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void playEndless()
    {

        
        SceneManager.LoadScene("FreeType");
        Debug.Log("Starting FreeType");

    }
}
