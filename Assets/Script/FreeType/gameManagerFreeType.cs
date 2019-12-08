using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerFreeType : MonoBehaviour {

    public Text inputText;    // Textbox where numbers appear
    public Button btn0;     
    public Button btn1;
    public AudioClip zeroAudio;     //audio voice
    public AudioClip oneAudio;      //audio voice
    public AudioClip goodString;

    AudioSource audioS;     

    int goodAnswer;     //Nimber of good answer. Will affect difficulty

    bool errorBool;     // Is latest entry an error ?
    bool timeUpBell; // Did the time's up bell already played ?

    public Camera cam;

    void Awake() {

    }

    // Use this for initialization
    void Start () {
             
        //inputText.GetComponent<Text>();
        btn0.GetComponent<Button>();
        btn1.GetComponent<Button>();

        audioS = GetComponent<AudioSource>();

        inputText.text = "Welcome";       //First message in Textbox

        btn0.onClick.AddListener(addZero);      //Button listener
        btn1.onClick.AddListener(addOne);

        errorBool = false; //Typo error detection value
        timeUpBell = false; //Time up value

        cam.backgroundColor = Color.green;
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    
    void addZero() {

        if (errorBool == false && timeUpBell == false)
        {
            if (inputText.text == "Welcome")
            {
                audioS.PlayOneShot(zeroAudio, 0.5f);
                inputText.text = "0";      //Remove welcome message if still there
            }
            else
            {
                audioS.PlayOneShot(zeroAudio, 0.5f);
                inputText.text += "0";        // Add 0 in text box
            }

        }
    }

    void addOne()
    {
        if (errorBool == false && timeUpBell == false)
        {
            if (inputText.text == "Welcome")
            {
                audioS.PlayOneShot(oneAudio, 0.5f);
                inputText.text = "1";  //Remove welcome message if still there
               
            }
            else
            {
                audioS.PlayOneShot(oneAudio, 0.5f);
                inputText.text += "1";    // Add 1 in text box
            }

        }
    }

    
}


    


