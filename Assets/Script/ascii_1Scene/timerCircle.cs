using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timerCircle : MonoBehaviour {

    public Image circle;
    public bool timeLoose;
    string charcterChain;   //CharcChain to play after ascii to binary translation
    public float timeSkipValue;    //Result depends on number of characters in the Byte characterChain to play.
    public float fillSpeed;     

    // Use this for initialization
    void Start () {
        fillSpeed = 0.0f;
        timeLoose = false;
        circle.fillAmount = 0.0f;
        charcterChain = PlayerPrefs.GetString("stringToPlay");
        calculateTime();
    }
	
	// Update is called once per frame
	void Update () {
        if (circle.fillAmount >= 1.00f) {
            timeLoose = true;
        }
	}

    public void resetCircle() {
       
        circle.fillAmount = 0.0f;
    }

    public void circleFill() {
        
        circle.fillAmount += fillSpeed;     //Circle filling function. When filled --> GameOver
        
    }



    public void calculateTime() {

        int chainLenght = charcterChain.Length;
        timeSkipValue = 5.0f / chainLenght / 60.0f;
        fillSpeed += timeSkipValue;
        //Debug.Log("timeSkipValue " + timeSkipValue);

    }

    public void increaseFillSpeed() {
        fillSpeed += timeSkipValue; //Accelerate fill speed

        //Debug.Log("fillSpeed " + fillSpeed);


    }
}
