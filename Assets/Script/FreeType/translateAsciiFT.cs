using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translateAsciiFT : MonoBehaviour {

    public Text inputText;
    public Text resultText;
    public Text historyText;

    public string historyS;
    
    string translateTemp;

    public gameManagerFreeType gm;

    AudioSource audioS;

    // Use this for initialization
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.pitch = 0.8f;

        historyText.text = "";

        historyS = "";
    }
       
	
	// Update is called once per frame
	void Update () {

        if (inputText.text.Length == 8) {
            translateTemp = inputText.text;
            translateAndAdd();
            audioS.PlayOneShot(gm.goodString, 0.5f);
            historyUpdate();
        }
	}

    void historyUpdate() {
        
        if (historyS == "")
        {
            historyS = inputText.text.ToString();
            inputText.text = "";
            historyText.text = historyS;
            //Debug.Log(historyS);
        }
        else if (historyS != "")
        {
            historyS = inputText.text.ToString() + "\n" + historyS;
            inputText.text = "";
            historyText.text = historyS;
            //Debug.Log(historyS);
        }
    }

    void translateAndAdd() {

        switch (translateTemp) {

            case "00100000": resultText.text += " "; break; //space	
            case "00100001": resultText.text += "!"; break; //exclamation mark	
            case "00100010": resultText.text += "\""; break; //double quote	
            case "00100011": resultText.text += "#"; break; //number	
            case "00100100": resultText.text += "$"; break; //dollar	
            case "00100101": resultText.text += "%"; break; //percent	
            case "00100110": resultText.text += "&"; break; //ampersand	
            case "00100111": resultText.text += "'"; break; //single quote	
            case "00101000": resultText.text += "("; break; //left parenthesis	
            case "00101001": resultText.text += ")"; break; //right parenthesis	
            case "00101010": resultText.text += "*"; break; //asterisk	
            case "00101011": resultText.text += "+"; break; //plus	
            case "00101100": resultText.text += ","; break; //comma	
            case "00101101": resultText.text += "-"; break; //minus	
            case "00101110": resultText.text += "."; break; //period	
            case "00101111": resultText.text += "/"; break; //slash	
            case "00110000": resultText.text += "0"; break; //zero	
            case "00110001": resultText.text += "1"; break; //one	
            case "00110010": resultText.text += "2"; break; //two	
            case "00110011": resultText.text += "3"; break; //three	
            case "00110100": resultText.text += "4"; break; //four	
            case "00110101": resultText.text += "5"; break; //five	
            case "00110110": resultText.text += "6"; break; //six	
            case "00110111": resultText.text += "7"; break; //seven	
            case "00111000": resultText.text += "8"; break; //eight	
            case "00111001": resultText.text += "9"; break; //nine	
            case "00111010": resultText.text += ":"; break; //colon	
            case "00111011": resultText.text += ";"; break; //semicolon	
            case "00111100": resultText.text += "<"; break; //less than	
            case "00111101": resultText.text += "="; break; //equality sign	
            case "00111110": resultText.text += ">"; break; //greater than	
            case "00111111": resultText.text += "?"; break; //question mark	
            case "01000000": resultText.text += "@"; break; //at sign	
            case "01000001": resultText.text += "A"; break; //	
            case "01000010": resultText.text += "B"; break; //	
            case "01000011": resultText.text += "C"; break; //	
            case "01000100": resultText.text += "D"; break; //	
            case "01000101": resultText.text += "E"; break; //	
            case "01000110": resultText.text += "F"; break; //	
            case "01000111": resultText.text += "G"; break; //	
            case "01001000": resultText.text += "H"; break; //	
            case "01001001": resultText.text += "I"; break; //	
            case "01001010": resultText.text += "J"; break; //	
            case "01001011": resultText.text += "K"; break; //	
            case "01001100": resultText.text += "L"; break; //	
            case "01001101": resultText.text += "M"; break; //	
            case "01001110": resultText.text += "N"; break; //	
            case "01001111": resultText.text += "O"; break; //	
            case "01010000": resultText.text += "P"; break; //	
            case "01010001": resultText.text += "Q"; break; //	
            case "01010010": resultText.text += "R"; break; //	
            case "01010011": resultText.text += "S"; break; //	
            case "01010100": resultText.text += "T"; break; //	
            case "01010101": resultText.text += "U"; break; //	
            case "01010110": resultText.text += "V"; break; //	
            case "01010111": resultText.text += "W"; break; //	
            case "01011000": resultText.text += "X"; break; //	
            case "01011001": resultText.text += "Y"; break; //	
            case "01011010": resultText.text += "Z"; break; //	
            case "01011011": resultText.text += "["; break; //left square bracket	
            case "01011100": resultText.text += @"\"; break; //backslash	
            case "01011101": resultText.text += "]"; break; //right square bracket	
            case "01011110": resultText.text += "^"; break; //caret / circumflex	
            case "01011111": resultText.text += "_"; break; //underscore	
            case "01100000": resultText.text += "`"; break; //grave / accent	
            case "01100001": resultText.text += "a"; break; //	
            case "01100010": resultText.text += "b"; break; //	
            case "01100011": resultText.text += "c"; break; //	
            case "01100100": resultText.text += "d"; break; //	
            case "01100101": resultText.text += "e"; break; //	
            case "01100110": resultText.text += "f"; break; //	
            case "01100111": resultText.text += "g"; break; //	
            case "01101000": resultText.text += "h"; break; //	
            case "01101001": resultText.text += "i"; break; //	
            case "01101010": resultText.text += "j"; break; //	
            case "01101011": resultText.text += "k"; break; //	
            case "01101100": resultText.text += "l"; break; //	
            case "01101101": resultText.text += "m"; break; //	
            case "01101110": resultText.text += "n"; break; //	
            case "01101111": resultText.text += "o"; break; //	
            case "01110000": resultText.text += "p"; break; //	
            case "01110001": resultText.text += "q"; break; //	
            case "01110010": resultText.text += "r"; break; //	
            case "01110011": resultText.text += "s"; break; //	
            case "01110100": resultText.text += "t"; break; //	
            case "01110101": resultText.text += "u"; break; //	
            case "01110110": resultText.text += "v"; break; //	
            case "01110111": resultText.text += "w"; break; //	
            case "01111000": resultText.text += "x"; break; //	
            case "01111001": resultText.text += "y"; break; //	
            case "01111010": resultText.text += "z"; break; //	
            case "01111011": resultText.text += "{"; break; //left curly bracket	
            case "01111100": resultText.text += "|"; break; //vertical bar	
            case "01111101": resultText.text += "}"; break; //right curly bracket	
            case "01111110": resultText.text += "~"; break; //tilde	
            case "01111111": resultText.text += "DEL"; break; //delete	
            case "10100000": resultText.text += " "; break; //space	
            case "10100001": resultText.text += "¡"; break; //	
            case "10100010": resultText.text += "¢"; break; //cent	
            case "10100011": resultText.text += "£"; break; //pound	
            case "10100100": resultText.text += "¤"; break; //currency sign	
            case "10100101": resultText.text += "¥"; break; //yen, yuan	
            case "10100110": resultText.text += "¦"; break; //broken bar	
            case "10100111": resultText.text += "§"; break; //section sign	
            case "10101000": resultText.text += "¨"; break; //	
            case "10101001": resultText.text += "©"; break; //copyright	
            case "10101010": resultText.text += "ª"; break; //ordinal indicator	
            case "10101011": resultText.text += "«"; break; //	
            case "10101100": resultText.text += "¬"; break; //	
            case "10101101": resultText.text += "­"; break; //	
            case "10101110": resultText.text += "®"; break; //registered trademark	
            case "10101111": resultText.text += "¯"; break; //	
            case "10110000": resultText.text += "°"; break; //degree	
            case "10110001": resultText.text += "±"; break; //plus-minus	
            case "10110010": resultText.text += "²"; break; //	
            case "10110011": resultText.text += "³"; break; //	
            case "10110100": resultText.text += "´"; break; //	
            case "10110101": resultText.text += "µ"; break; //mu	
            case "10110110": resultText.text += "¶"; break; //pilcrow	
            case "10110111": resultText.text += "·"; break; //	
            case "10111000": resultText.text += "¸"; break; //	
            case "10111001": resultText.text += "¹"; break; //	
            case "10111010": resultText.text += "º"; break; //ordinal indicator	
            case "10111011": resultText.text += "»"; break; //	
            case "10111100": resultText.text += "¼"; break; //	
            case "10111101": resultText.text += "½"; break; //	
            case "10111110": resultText.text += "¾"; break; //	
            case "10111111": resultText.text += "¿"; break; //inverted question mark	
            case "11000000": resultText.text += "À"; break; //	
            case "11000001": resultText.text += "Á"; break; //	
            case "11000010": resultText.text += "Â"; break; //	
            case "11000011": resultText.text += "Ã"; break; //	
            case "11000100": resultText.text += "Ä"; break; //	
            case "11000101": resultText.text += "Å"; break; //	
            case "11000110": resultText.text += "Æ"; break; //	
            case "11000111": resultText.text += "Ç"; break; //	
            case "11001000": resultText.text += "È"; break; //	
            case "11001001": resultText.text += "É"; break; //	
            case "11001010": resultText.text += "Ê"; break; //	
            case "11001011": resultText.text += "Ë"; break; //	
            case "11001100": resultText.text += "Ì"; break; //	
            case "11001101": resultText.text += "Í"; break; //	
            case "11001110": resultText.text += "Î"; break; //	
            case "11001111": resultText.text += "Ï"; break; //	
            case "11010000": resultText.text += "Ð"; break; //	
            case "11010001": resultText.text += "Ñ"; break; //	
            case "11010010": resultText.text += "Ò"; break; //	
            case "11010011": resultText.text += "Ó"; break; //	
            case "11010100": resultText.text += "Ô"; break; //	
            case "11010101": resultText.text += "Õ"; break; //	
            case "11010110": resultText.text += "Ö"; break; //	
            case "11010111": resultText.text += "×"; break; //multiplication sign	
            case "11011000": resultText.text += "Ø"; break; //	
            case "11011001": resultText.text += "Ù"; break; //	
            case "11011010": resultText.text += "Ú"; break; //	
            case "11011011": resultText.text += "Û"; break; //	
            case "11011100": resultText.text += "Ü"; break; //	
            case "11011101": resultText.text += "Ý"; break; //	
            case "11011110": resultText.text += "Þ"; break; //	
            case "11011111": resultText.text += "ß"; break; //	
            case "11100000": resultText.text += "à"; break; //	
            case "11100001": resultText.text += "á"; break; //	
            case "11100010": resultText.text += "â"; break; //	
            case "11100011": resultText.text += "ã"; break; //	
            case "11100100": resultText.text += "ä"; break; //	
            case "11100101": resultText.text += "å"; break; //	
            case "11100110": resultText.text += "æ"; break; //	
            case "11100111": resultText.text += "ç"; break; //	
            case "11101000": resultText.text += "è"; break; //	
            case "11101001": resultText.text += "é"; break; //	
            case "11101010": resultText.text += "ê"; break; //	
            case "11101011": resultText.text += "ë"; break; //	
            case "11101100": resultText.text += "ì"; break; //	
            case "11101101": resultText.text += "í"; break; //	
            case "11101110": resultText.text += "î"; break; //	
            case "11101111": resultText.text += "ï"; break; //	
            case "11110000": resultText.text += "ð"; break; //	
            case "11110001": resultText.text += "ñ"; break; //	
            case "11110010": resultText.text += "ò"; break; //	
            case "11110011": resultText.text += "ó"; break; //	
            case "11110100": resultText.text += "ô"; break; //	
            case "11110101": resultText.text += "õ"; break; //	
            case "11110110": resultText.text += "ö"; break; //	
            case "11110111": resultText.text += "÷"; break; //obelus	
            case "11111000": resultText.text += "ø"; break; //	
            case "11111001": resultText.text += "ù"; break; //	
            case "11111010": resultText.text += "ú"; break; //	
            case "11111011": resultText.text += "û"; break; //	
            case "11111100": resultText.text += "ü"; break; //	
            case "11111101": resultText.text += "ý"; break; //	
            case "11111110": resultText.text += "þ"; break; //	
            case "11111111": resultText.text += "ÿ"; break; //
           
        }
       
    }

}
