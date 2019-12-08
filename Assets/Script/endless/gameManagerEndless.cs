using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerEndless : MonoBehaviour {

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
    int goodAnswer;     //Nimber of good answer. Will affect difficulty
    

    float timer;        //Timer value used to switch to game over screen. It lets the player see the mistake before going to GO screen.
    float fillSpeed;

    bool errorBool;     // Is latest entry an error ?
    bool timeUpBell; // Did the time's up bell already played ?
    bool levelClearedBool;
    bool levelClearedSoundPlayed;

    public timerCircle tc;  //loading TimerCircle class to reset and change time circle status
    public cameraScript cs; //loading CameraScript class for background color change
    
    

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

       

        timer = 0.0f;   
        fillSpeed = 0.0005f;

        errorBool = false; //Typo error detection value
        timeUpBell = false; //Time up value
        levelClearedBool = false;
        levelClearedSoundPlayed = false;

        goodAnswer = 0; //Score

        nextNumber();       //Start the game by asking for the first number.
               
    }
	
	// Update is called once per frame
	void Update () {
        gameOver();     //Continuously check time for game over

        if (levelClearedBool == false) {
            tc.circleFill();   // Executing circleFill() in TimerCircle class using shrinkSpeed float
        } else if (levelClearedBool == true) {
            tc.resetCircle();
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
            }
            else
            {
                inputText.text += "0";        // Add 0 in text box
            }

            if (expectedNbr == 1 && timeUpBell == false)
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
            }
            else
            {
                inputText.text += "1";    // Add 1 in text box
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
            }
        }
    }



    void nextNumber() {

        expectedNbr = Random.Range(0, 101);

        if (expectedNbr%2 == 0)
        {
            //even number
            audioS.PlayOneShot(zeroAudio, 0.5f);
            expectedNbr = 0;
        }
        else if (expectedNbr % 2 != 0)
        {
            //odd number
            audioS.PlayOneShot(oneAudio, 0.5f);
            expectedNbr = 1;
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
}


    


