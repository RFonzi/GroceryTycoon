using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class optionsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Image soundBlocker = GameObject.Find("soundBlockerImg").GetComponent<Image>();
        soundBlocker.enabled = !soundBlocker.enabled;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // toggle sound on click of soundToggleButton
    public void soundToggle()
    {
        // switch On/Off state of button text and icon
        Image soundBlocker = GameObject.Find("soundBlockerImg").GetComponent<Image>();
        if (GameObject.Find("soundToggleButton").GetComponentInChildren<Text>().text == "Sound is On")
        {
            soundBlocker.enabled = !soundBlocker.enabled;
            GameObject.Find("soundToggleButton").GetComponentInChildren<Text>().text = "Sound is Off";
        }
        else
        {
            GameObject.Find("soundToggleButton").GetComponentInChildren<Text>().text = "Sound is On";
            soundBlocker.enabled = !soundBlocker.enabled;
        }
    }
}
