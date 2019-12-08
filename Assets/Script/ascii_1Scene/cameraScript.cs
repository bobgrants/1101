using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    public timerCircle tc;

    public Camera cameraObject;
    Color color1;
    Color color2;


	// Use this for initialization
	void Start () {
        color1 = Color.green;
        color2 = Color.red;

        
        cameraObject.backgroundColor = Color.Lerp(color1, color2, tc.circle.fillAmount);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void colorChange() {
        cameraObject.backgroundColor = Color.Lerp(color1, color2, tc.circle.fillAmount);
        //Debug.Log(tc.circle.fillAmount);
    }
}
