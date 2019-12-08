using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour {

    float posf = 0.0f;
    public float speedf;

    public static scroll current;
    Renderer rend;
    

    float screenHeight;
    float screenWidth;

    
    
    // Use this for initialization
    void Start () {
        current = this;
        posf = 0.0f;
        //speedf = -0.001f;
        rend = GetComponent<Renderer>();

        //Adapting background quad to screen size
        screenHeight = Camera.main.orthographicSize * 2.0f;
        Debug.Log("Screen Height: " + screenHeight);
        screenWidth = screenHeight * Screen.width / Screen.height;
        Debug.Log("Screen Width: " + screenWidth);
        transform.localScale = new Vector3(screenWidth , screenHeight , 1);
        Debug.Log("Local Scale: " + transform.localScale);

        //Set texture to wrap when pushed down
        //Should be working only via editor but seems to not work sometimes
        rend.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
    }

    // Update is called once per frame
    void Update () {
        posf -= speedf;

        rend.material.mainTextureOffset = new Vector2(0, posf);

    }

    void resetImages() {
      

    }
}
