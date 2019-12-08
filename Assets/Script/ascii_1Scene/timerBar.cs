using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timerBar : MonoBehaviour {

    
    public bool timeLoose;
    string characterChain;   //CharcChain to play after ascii to binary translation
    public float timeSkipValue;    //Result depends on number of characters in the Byte characterChain to play.
    public float shrinkSpeed;
    RectTransform barRT;
    Vector2 barSize;
    Vector2 barPos;
    float barWidth;


    // Use this for initialization
    void Start () {

        barRT = gameObject.GetComponent<RectTransform>();
        barWidth = barRT.rect.width;
        barSize = barRT.sizeDelta;
        barPos = barRT.position;

        

        timeLoose = false;
     
        characterChain = PlayerPrefs.GetString("stringToPlay");
        calculateTime();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void resetBar() {
        gameObject.GetComponent<RectTransform>().sizeDelta = barSize;
        gameObject.GetComponent<RectTransform>().position = barPos;
        Debug.Log("Reset BAR");
    }

    public void barShrink() {
       gameObject.GetComponent<RectTransform>().sizeDelta -= new Vector2(shrinkSpeed, 0.0f);
       //gameObject.GetComponent<RectTransform>().position = barPos;
       //Debug.Log("gameObject.GetComponent<RectTransform>().sizeDelta " + gameObject.GetComponent<RectTransform>().sizeDelta);
    }



    public void calculateTime() {

        int chainLenght = characterChain.Length;
        //timeSkipValue = barWidth / chainLenght / 60.0f;
        timeSkipValue = barWidth/5/60;
        shrinkSpeed += timeSkipValue;
        

    }

    public void increaseFillSpeed() {
        shrinkSpeed += timeSkipValue; //Accelerate fill speed
        
    }
}
