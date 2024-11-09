using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText.text = "Congratulations,"+ PlayerPrefs.GetString("myName") + " has completed the game and achieved his goal";
    }
}
