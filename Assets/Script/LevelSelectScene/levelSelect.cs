using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {

    public Button Mustache, BeerGlass, SadFace, Butt, Snail, Oops, Face, Rose, fckOff, Koala, Bird‏, Katulu, Fish, Mouse, Panda, Sleeping; //, Pig, Spider, Needle, Guitar, Smiths, Chainsword, test;

    public asciiList al;

    string levelBinary;
    string resultText;
    public string levelBeingPlayed;

    //public int MustacheStatus, BeerGlassStatus, SadFaceStatus, ButtStatus, SnailStatus, OopsFaceStatus, FaceStatus, RoseStatus, fckOffStatus, KoalaStatus, BirdStatus, KatuluStatus, FishStatus, MouseStatus, PandaStatus, SleepingStatus; //, PigStatus, SpiderStatus, NeedleStatus, GuitarStatus, SmithsStatus, ChainswordStatus;

    Dictionary<string, int> levelsList = new Dictionary<string, int>();
     
    // Use this for initialization
    void Awake() {

        levelsList.Add("Mustache", PlayerPrefs.GetInt("MustacheStatus"));
        levelsList.Add("BeerGlass", PlayerPrefs.GetInt("BeerGlassStatus"));
        levelsList.Add("SadFace", PlayerPrefs.GetInt("SadFaceStatus"));
        levelsList.Add("Butt", PlayerPrefs.GetInt("ButtStatus"));
        levelsList.Add("Snail", PlayerPrefs.GetInt("SnailStatus"));
        levelsList.Add("Oops", PlayerPrefs.GetInt("OopsStatus"));
        levelsList.Add("Face", PlayerPrefs.GetInt("FaceStatus"));
        levelsList.Add("Rose", PlayerPrefs.GetInt("RoseStatus"));
        levelsList.Add("fckOff", PlayerPrefs.GetInt("fckOffStatus"));
        levelsList.Add("Koala", PlayerPrefs.GetInt("KoalaStatus"));
        levelsList.Add("Bird", PlayerPrefs.GetInt("BirdStatus"));
        levelsList.Add("Katulu", PlayerPrefs.GetInt("KatuluStatus"));
        levelsList.Add("Fish", PlayerPrefs.GetInt("FishStatus"));
        levelsList.Add("Mouse", PlayerPrefs.GetInt("MouseStatus"));
        levelsList.Add("Panda", PlayerPrefs.GetInt("PandaStatus"));
        levelsList.Add("Sleeping", PlayerPrefs.GetInt("SleepingStatus"));
        //levelsList.Add("test", PlayerPrefs.GetInt("testStatus"));

        // int[] levelsList = new int[16] {MustacheStatus, BeerGlassStatus, SadFaceStatus, ButtStatus, SnailStatus, OopsFaceStatus, FaceStatus, 
        //RoseStatus, fckOffStatus, KoalaStatus, BirdStatus, KatuluStatus, FishStatus, MouseStatus, PandaStatus, SleepingStatus }; //, PigStatus, SpiderStatus, NeedleStatus, GuitarStatus, SmithsStatus, ChainswordStatus;

        //Debug.Log("Array TEST: " + levelsList ["Mustache"]);
        //Debug.Log("levelsList.Length: " + levelsList.Count);

    }

    void Start () {
      
        //test.onClick.AddListener(delegate { setLevelPlayed("test"); LoadLevel(al.test); });
        Mustache.onClick.AddListener(delegate { setLevelPlayed("Mustache"); LoadLevel(al.Mustache); });
        BeerGlass.onClick.AddListener(delegate { setLevelPlayed("BeerGlass"); LoadLevel(al.BeerGlass);});
        SadFace.onClick.AddListener(delegate { setLevelPlayed("SadFace"); LoadLevel(al.SadFace); });
        Butt.onClick.AddListener(delegate { setLevelPlayed("Butt"); LoadLevel(al.Butt);});
        Snail.onClick.AddListener(delegate { setLevelPlayed("Snail"); LoadLevel(al.Snail);});
        Oops.onClick.AddListener(delegate { setLevelPlayed("Oops"); LoadLevel(al.OopsFace);});
        Face.onClick.AddListener(delegate { setLevelPlayed("Face"); LoadLevel(al.Face); });
        Rose.onClick.AddListener(delegate { setLevelPlayed("Rose"); LoadLevel(al.Rose); });
        fckOff.onClick.AddListener(delegate { setLevelPlayed("fckOff"); LoadLevel(al.fckOff);});
        Koala.onClick.AddListener(delegate { setLevelPlayed("Koala"); LoadLevel(al.Koala);});
        Bird‏.onClick.AddListener(delegate { setLevelPlayed("Bird"); LoadLevel(al.Bird‏);});
        Katulu.onClick.AddListener(delegate { setLevelPlayed("Katulu"); LoadLevel(al.Katulu);});
        Fish.onClick.AddListener(delegate { setLevelPlayed("Fish"); LoadLevel(al.Fish); });
        Mouse.onClick.AddListener(delegate { setLevelPlayed("Mouse"); LoadLevel(al.Mouse);});
        Panda.onClick.AddListener(delegate { setLevelPlayed("Panda"); LoadLevel(al.Panda);});
        Sleeping.onClick.AddListener(delegate { setLevelPlayed("Sleeping"); LoadLevel(al.Sleeping);});
        //Pig.onClick.AddListener(delegate { LoadLevel(al.Pig); levelBeingPlayed = "Mustache";});
        //Spider.onClick.AddListener(delegate { LoadLevel(al.Spider); levelBeingPlayed = "Mustache";});
        //Needle.onClick.AddListener(delegate { LoadLevel(al.Needle); levelBeingPlayed = "Mustache";});
        //Guitar.onClick.AddListener(delegate { LoadLevel(al.Guitar); levelBeingPlayed = "Mustache";});
        //Smiths.onClick.AddListener(delegate { LoadLevel(al.Smiths); levelBeingPlayed = "Mustache";});
        //Chainsword.onClick.AddListener(delegate { LoadLevel(al.Chainsword); levelBeingPlayed = "Mustache";});
        
        resultText = "";

        buttonColors();
    }

    void setLevelPlayed(string s1) {

        levelBeingPlayed = s1;
       
    }

    void buttonColors() {

        foreach (string s2 in levelsList.Keys) {
            if (levelsList[s2] == 1){
                
                GameObject.Find(s2.ToString()).GetComponent<Image>().color = Color.green; 
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void LoadLevel(string levelAscii) {
        //Debug.Log("al.Value" + levelAscii);

        //Debug.Log(levelAscii[0]);

        resultText = "";

        int i = 0;
        for (i = 0; i < levelAscii.Length; i++)
        {
            //Debug.Log("LEVELASCII i: " + levelAscii[i]);
            switch (levelAscii[i].ToString()) {
                
                case @" ": resultText += "00100000"; break; //space
                case @"!": resultText += "00100001"; break; //exclamation mark
                case @"""":	resultText += "00100010"; Debug.Log("Debug Guillemet"); break; //double quote
                case @"#": resultText += "00100011"; break; //number
                case @"$": resultText += "00100100"; break; //dollar
                case @"%": resultText += "00100101"; break; //percent
                case @"&": resultText += "00100110"; break; //ampersand
                case "\'": resultText += "00100111"; break; //single quote
                case @"(": resultText += "00101000"; break; //left parenthesis
                case @")": resultText += "00101001"; break; //right parenthesis
                case @"*": resultText += "00101010"; break; //asterisk
                case @"+": resultText += "00101011"; break; //plus
                case @",": resultText += "00101100"; break; //comma
                case @"-": resultText += "00101101"; break; //minus
                case @".": resultText += "00101110"; break; //period
                case @"/": resultText += "00101111"; break; //slash
                case @"0": resultText += "00110000"; break; //zero
                case @"1": resultText += "00110001"; break; //one
                case @"2": resultText += "00110010"; break; //two
                case @"3": resultText += "00110011"; break; //three
                case @"4": resultText += "00110100"; break; //four
                case @"5": resultText += "00110101"; break; //five
                case @"6": resultText += "00110110"; break; //six
                case @"7": resultText += "00110111"; break; //seven
                case @"8": resultText += "00111000"; break; //eight
                case @"9": resultText += "00111001"; break; //nine
                case @":": resultText += "00111010"; break; //colon
                case @";": resultText += "00111011"; break; //semicolon
                case @"<": resultText += "00111100"; break; //less than
                case @"=": resultText += "00111101"; break; //equality sign
                case @">": resultText += "00111110"; break; //greater than
                case @"?": resultText += "00111111"; break; //question mark
                case @"@": resultText += "01000000"; break; //at sign
                case @"A": resultText += "01000001"; break; //
                case @"B": resultText += "01000010"; break; //
                case @"C": resultText += "01000011"; break; //
                case @"D": resultText += "01000100"; break; //
                case @"E": resultText += "01000101"; break; //
                case @"F": resultText += "01000110"; break; //
                case @"G": resultText += "01000111"; break; //
                case @"H": resultText += "01001000"; break; //
                case @"I": resultText += "01001001"; break; //
                case @"J": resultText += "01001010"; break; //
                case @"K": resultText += "01001011"; break; //
                case @"L": resultText += "01001100"; break; //
                case @"M": resultText += "01001101"; break; //
                case @"N": resultText += "01001110"; break; //
                case @"O": resultText += "01001111"; break; //
                case @"P": resultText += "01010000"; break; //
                case @"Q": resultText += "01010001"; break; //
                case @"R": resultText += "01010010"; break; //
                case @"S": resultText += "01010011"; break; //
                case @"T": resultText += "01010100"; break; //
                case @"U": resultText += "01010101"; break; //
                case @"V": resultText += "01010110"; break; //
                case @"W": resultText += "01010111"; break; //
                case @"X": resultText += "01011000"; break; //
                case @"Y": resultText += "01011001"; break; //
                case @"Z": resultText += "01011010"; break; //
                case @"[": resultText += "01011011"; break; //left square bracket
                case @"\":	resultText += "01011100"; break; //backslash
                case @"]": resultText += "01011101"; break; //right square bracket
                case "^": resultText += "01011110"; break; //caret / circumflex
                case @"_": resultText += "01011111"; break; //underscore
                case @"`": resultText += "01100000"; break; //grave / accent
                case @"a": resultText += "01100001"; break; //
                case @"b": resultText += "01100010"; break; //
                case @"c": resultText += "01100011"; break; //
                case @"d": resultText += "01100100"; break; //
                case @"e": resultText += "01100101"; break; //
                case @"f": resultText += "01100110"; break; //
                case @"g": resultText += "01100111"; break; //
                case @"h": resultText += "01101000"; break; //
                case @"i": resultText += "01101001"; break; //
                case @"j": resultText += "01101010"; break; //
                case @"k": resultText += "01101011"; break; //
                case @"l": resultText += "01101100"; break; //
                case @"m": resultText += "01101101"; break; //
                case @"n": resultText += "01101110"; break; //
                case @"o": resultText += "01101111"; break; //
                case @"p": resultText += "01110000"; break; //
                case @"q": resultText += "01110001"; break; //
                case @"r": resultText += "01110010"; break; //
                case @"s": resultText += "01110011"; break; //
                case @"t": resultText += "01110100"; break; //
                case @"u": resultText += "01110101"; break; //
                case @"v": resultText += "01110110"; break; //
                case @"w": resultText += "01110111"; break; //
                case @"x": resultText += "01111000"; break; //
                case @"y": resultText += "01111001"; break; //
                case @"z": resultText += "01111010"; break; //
                case @"{": resultText += "01111011"; break; //left curly bracket
                case @"|": resultText += "01111100"; break; //vertical bar
                case @"}": resultText += "01111101"; break; //right curly bracket
                case @"~": resultText += "01111110"; break; //tilde
                case @"DEL": resultText += "01111111"; break; //delete
                case null: resultText += "10100000"; break; //space
                case @"¡": resultText += "10100001"; break; //
                case @"¢": resultText += "10100010"; break; //cent
                case @"£": resultText += "10100011"; break; //pound
                case @"¤": resultText += "10100100"; break; //currency sign
                case @"¥": resultText += "10100101"; break; //yen, yuan
                case @"¦": resultText += "10100110"; break; //broken bar
                case @"§": resultText += "10100111"; break; //section sign
                case @"¨": resultText += "10101000"; break; //
                case @"©": resultText += "10101001"; break; //copyright
                case @"ª": resultText += "10101010"; break; //ordinal indicator
                case @"«": resultText += "10101011"; break; //
                case @"¬": resultText += "10101100"; break; //
                case @"­": resultText += "10101101"; break; //
                case @"®": resultText += "10101110"; break; //registered trademark
                case @"¯": resultText += "10101111"; break; //
                case @"°": resultText += "10110000"; break; //degree
                case @"±": resultText += "10110001"; break; //plus-minus
                case @"²": resultText += "10110010"; break; //
                case @"³": resultText += "10110011"; break; //
                case @"´": resultText += "10110100"; break; //
                case @"µ": resultText += "10110101"; break; //mu
                case @"¶": resultText += "10110110"; break; //pilcrow
                case @"·": resultText += "10110111"; break; //
                case @"¸": resultText += "10111000"; break; //
                case @"¹": resultText += "10111001"; break; //
                case @"º": resultText += "10111010"; break; //ordinal indicator
                case @"»": resultText += "10111011"; break; //
                case @"¼": resultText += "10111100"; break; //
                case @"½": resultText += "10111101"; break; //
                case @"¾": resultText += "10111110"; break; //
                case @"¿": resultText += "10111111"; break; //inverted question mark
                case @"À": resultText += "11000000"; break; //
                case @"Á": resultText += "11000001"; break; //
                case @"Â": resultText += "11000010"; break; //
                case @"Ã": resultText += "11000011"; break; //
                case @"Ä": resultText += "11000100"; break; //
                case @"Å": resultText += "11000101"; break; //
                case @"Æ": resultText += "11000110"; break; //
                case @"Ç": resultText += "11000111"; break; //
                case @"È": resultText += "11001000"; break; //
                case @"É": resultText += "11001001"; break; //
                case @"Ê": resultText += "11001010"; break; //
                case @"Ë": resultText += "11001011"; break; //
                case @"Ì": resultText += "11001100"; break; //
                case @"Í": resultText += "11001101"; break; //
                case @"Î": resultText += "11001110"; break; //
                case @"Ï": resultText += "11001111"; break; //
                case @"Ð": resultText += "11010000"; break; //
                case @"Ñ": resultText += "11010001"; break; //
                case @"Ò": resultText += "11010010"; break; //
                case @"Ó": resultText += "11010011"; break; //
                case @"Ô": resultText += "11010100"; break; //
                case @"Õ": resultText += "11010101"; break; //
                case @"Ö": resultText += "11010110"; break; //
                case @"×": resultText += "11010111"; break; //multiplication sign
                case @"Ø": resultText += "11011000"; break; //
                case @"Ù": resultText += "11011001"; break; //
                case @"Ú": resultText += "11011010"; break; //
                case @"Û": resultText += "11011011"; break; //
                case @"Ü": resultText += "11011100"; break; //
                case @"Ý": resultText += "11011101"; break; //
                case @"Þ": resultText += "11011110"; break; //
                case @"ß": resultText += "11011111"; break; //
                case @"à": resultText += "11100000"; break; //
                case @"á": resultText += "11100001"; break; //
                case @"â": resultText += "11100010"; break; //
                case @"ã": resultText += "11100011"; break; //
                case @"ä": resultText += "11100100"; break; //
                case @"å": resultText += "11100101"; break; //
                case @"æ": resultText += "11100110"; break; //
                case @"ç": resultText += "11100111"; break; //
                case @"è": resultText += "11101000"; break; //
                case @"é": resultText += "11101001"; break; //
                case @"ê": resultText += "11101010"; break; //
                case @"ë": resultText += "11101011"; break; //
                case @"ì": resultText += "11101100"; break; //
                case @"í": resultText += "11101101"; break; //
                case @"î": resultText += "11101110"; break; //
                case @"ï": resultText += "11101111"; break; //
                case @"ð": resultText += "11110000"; break; //
                case @"ñ": resultText += "11110001"; break; //
                case @"ò": resultText += "11110010"; break; //
                case @"ó": resultText += "11110011"; break; //
                case @"ô": resultText += "11110100"; break; //
                case @"õ": resultText += "11110101"; break; //
                case @"ö": resultText += "11110110"; break; //
                case @"÷": resultText += "11110111"; break; //obelus
                case @"ø": resultText += "11111000"; break; //
                case @"ù": resultText += "11111001"; break; //
                case @"ú": resultText += "11111010"; break; //
                case @"û": resultText += "11111011"; break; //
                case @"ü": resultText += "11111100"; break; //
                case @"ý": resultText += "11111101"; break; //
                case @"þ": resultText += "11111110"; break; //
                case @"ÿ": resultText += "11111111"; break; //
                    
            }
            //Debug.Log("Binary chain to play " + resultText);
            
        }
        //Debug.Log("Level being played END: " + levelBeingPlayed);
        PlayerPrefs.SetString("levelBeingPlayed", levelBeingPlayed);
        PlayerPrefs.SetString("stringToPlay", resultText);
        PlayerPrefs.Save();

        SceneManager.LoadScene("ascii_1");

    }
}
