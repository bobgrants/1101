using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public Text inputText;    // Textbox where numbers appear
    public Button btn0;     
    public Button btn1;
    public AudioClip zeroAudio;     //audio voice
    public AudioClip oneAudio;      //audio voice
    public AudioClip errorAudio;
    public AudioClip bellLoose;
    public AudioClip goodString;
    public AudioClip levelCleared;

    AudioSource audioS;     

   
    int expectedNbr;    //This store the number we expect the player to press
    int goodAnswer;     //Number of good answer. Will affect difficulty
    

    float timer;        //Timer value used to switch to game over screen. It lets the player see the mistake before going to GO screen.
    float fillSpeed;

    bool errorBool;     // Is latest entry an error ?
    bool timeUpBell;    // Did the time's up bell already played ?
    bool levelClearedBool;
    bool levelClearedSoundPlayed;

    public timerCircle tc;  //loading TimerCircle class to reset and change time circle status
    public cameraScript cs; //loading CameraScript class for background color change
    public asciiList al;    //loading asciiList class where all ascii art are stored
    public timerBar tb;     //loading timerBar script to shrink bar with time

    string currentCode;
    string levelBeingPlayed;

    public Text timeBar;

    void Awake() {
        //= al.fish;  //Load the string to be used before anything else
        
        currentCode = PlayerPrefs.GetString("stringToPlay");
        levelBeingPlayed = PlayerPrefs.GetString("levelBeingPlayed");
        //GUIStyle style = new GUIStyle();
        //style.richText = true;
        //GUILayout.Label("<size=30>Some <color=yellow>RICH</color> text</size>", style);
    }

    // Use this for initialization
    void Start () {
      
        btn0.GetComponent<Button>();
        btn1.GetComponent<Button>();

        audioS = GetComponent<AudioSource>();

        inputText.text = "Welcome";       //First message in Textbox

        btn0.onClick.AddListener(addZero);      //Button listener
        btn1.onClick.AddListener(addOne);

        timer = 0.0f;   
        fillSpeed = 0.0005f;

        errorBool = false; //Typo error detection value
        timeUpBell = false; //Time up value
        levelClearedBool = false;
        levelClearedSoundPlayed = false;

        goodAnswer = 0; //Score

        nextNumber();       //Start the game by asking for the first number.

        timeBar.GetComponent<Text>().supportRichText = true;
        //timeBar.GetComponent<Text>().text = "<color=#00ffffff>TEST</color>" + "<color=#ff00ffff>TEST</color>";
        timeBar.GetComponent<Text>().text = "";

        timerBarText();
    }
	
	// Update is called once per frame
	void Update () {
        gameOver();     //Continuously check time for game over

        if (levelClearedBool == false) {
            tc.circleFill();   // Executing circleFill() in TimerCircle class using shrinkSpeed float
            tb.barShrink();
        } else if (levelClearedBool == true) {
            tc.resetCircle();
            tb.resetBar();
        }
        

        cs.colorChange();   //Background color change in CameraScript class

        endLevelBehaviour();

    }

    void endLevelBehaviour() {

        if (levelClearedBool == true)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 1.5f && levelClearedSoundPlayed == false) {
            audioS.PlayOneShot(levelCleared, 0.5f);
            levelClearedSoundPlayed = true;
        } else if (timer >= 3.0f && levelClearedSoundPlayed == true) {
            SceneManager.LoadScene("levelSelect");

        }

    }

    void addZero() {

        if (errorBool == false && timeUpBell == false)
        {
            if (inputText.text == "Welcome")
            {
                inputText.text = "0";      //Remove welcome message if still there
                currentCode = currentCode.Remove(0, 1);     //Remove 1 character of string as it has been played
            }
            else
            {
                inputText.text += "0";        // Add 0 in text box
                currentCode = currentCode.Remove(0, 1);     //Remove 1 character of string as it has been played

            }

            if (expectedNbr == 1 && timeUpBell == false)
            {
                audioS.PlayOneShot(errorAudio, 0.5f);
                errorBool = true;
            }
            else
            {
                    
                    tb.resetBar();
                    nextNumber();   //Execute next number generation 
                    tc.resetCircle();   //Reset circle to empty state
                    trackGoodAnswer();  //Score value increment
                    cs.colorChange();   //Restart ColorChange function in cameraScript class
                    //Debug.Log(goodAnswer);  //Print score debug
            }
        }
    }

    void addOne()
    {
        if (errorBool == false && timeUpBell == false)
        {
            if (inputText.text == "Welcome")
            {
                inputText.text = "1";  //Remove welcome message if still there
                currentCode = currentCode.Remove(0, 1);     //Remove 1st character of string as it has been played
            }
            else
            {
                inputText.text += "1";    // Add 1 in text box
                currentCode = currentCode.Remove(0, 1);     //Remove 1st character of string as it has been played
            }
            
            if (expectedNbr == 0 && timeUpBell == false)
            {
                audioS.PlayOneShot(errorAudio, 0.5f);
                errorBool = true;
            }
            else
            {
                
                nextNumber();   //Execute next number generation 
                tc.resetCircle();   //Reset circle to empty state
                trackGoodAnswer();  //Score value increment
                cs.colorChange();   //Restart ColorChange function in cameraScript class
                tb.resetBar();
            }
        }
    }



    void nextNumber() {

        // Debug.Log("nextNumberLog: " + currentCode[0].ToString());   //first number in String currentCode
        // Debug.Log("Current String: " + currentCode);        //Print full current code String to verify first character has been removed

        if (currentCode == string.Empty)
        {
            PlayerPrefs.SetInt(levelBeingPlayed + "Status", 1);
            PlayerPrefs.Save();
            levelClearedBool = true;
            //Debug.Log("SUCCESS !!!");
           
            

        }

        if (currentCode[0].ToString() == "0" && currentCode != string.Empty)
        {
            //even number
            audioS.PlayOneShot(zeroAudio, 0.5f);
            expectedNbr = 0;
            timerBarText();
            //Debug.Log("Expected Number 0: " + expectedNbr);     //Print expected number to verify it match the expectation
        }
        else if (currentCode[0].ToString() == "1" && currentCode != string.Empty)
        {
            //odd number
            audioS.PlayOneShot(oneAudio, 0.5f);
            expectedNbr = 1;
            timerBarText();
            //Debug.Log("Expected Number 1: " + expectedNbr); //Print expected number to verify it match the expectation
        }
         
    }

    void trackGoodAnswer()  //Increment goodAnswer int
    {
        goodAnswer++;   //Increment Score
        setDifficulty();    //Call Set difficulty function
    }


    void setDifficulty() {
        if (goodAnswer % 10 == 0) {     //Detecting if the current value of goodAnswer is a multiple of 10, if so, increase difficulty 
            fillSpeed += 0.0010f;       // per fill 0.0010f
            //Debug.Log("FILL SPEED: " + shrinkSpeed);      //Print actual fill speed
        }
    }

        

    void gameOver() {
        if (errorBool == true)
        {
            timer += Time.deltaTime;    // Timer before switching to game over screen
        }
        if (tc.timeLoose == true)   //Timeloose is set to true when the circle filled up in timerCircle class
        {
            playBell();     //Call play bell function
            timer += Time.deltaTime;    // Timer before switching to game over screen
        }
        if (timer >= 1.5f && levelClearedBool == false)
        {
            SceneManager.LoadScene("gameOver");     //Switch to game over screen
            //Debug.Log("ENDING");
        }

    }
    void playBell()
    {

        if (timeUpBell == false && errorBool == false && levelClearedBool == false)      //Verify that bell did not play, or if player lost by a typo mistake
        {
            audioS.PlayOneShot(bellLoose, 0.5f);
            timeUpBell = true;

        }
    }

    void timerBarText() {
        Debug.Log("expectedNbr loop "+expectedNbr);
        string s1 = ""; int i = 0; int i2; int i3 = 0;

        timeBar.GetComponent<Text>().text = "";

        for (i = 0; i <= 8; i++) {

            i2 = Random.Range(0, 2); //We need only 0 and 1. Random.range last digits is exclusive, so we have to put (0, 2)
            s1 += i2.ToString();
            //Debug.Log("s1 " + s1);
        }

        for (i3 = 0; i3 < s1.Length; i3++) {
            if (s1[i3].ToString() == "1" && s1[i3].ToString() == expectedNbr.ToString())
            {
                timeBar.GetComponent<Text>().text += "<color=#20C20E>1</color>";
                //Debug.Log("add 1 green");
            }
            else if (s1[i3].ToString() == "0" && s1[i3].ToString() == expectedNbr.ToString())
            {
                timeBar.GetComponent<Text>().text += "<color=#20C20E>0</color>";
                //Debug.Log("add 0 green");
            }
            else { timeBar.GetComponent<Text>().text += s1[i3].ToString(); }
        }
    }
}


   


