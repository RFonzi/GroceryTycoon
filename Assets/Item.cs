using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Item : MonoBehaviour {

    public GameObject itemHeader;
    public GameObject buttonText;
    public GameObject prefabItemText;
    public GameObject prefabButton;
    public RectTransform ParentPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // display proper item in ItemPanel
    public void displayItemMenu()
    {
        string itemName = buttonText.GetComponent<Text>().text;

        for(int i=0; i<5; i++)
        {
            // for the item text
            GameObject listItemText = (GameObject)Instantiate(prefabItemText);
            listItemText.transform.SetParent(ParentPanel, false);
            listItemText.transform.localScale = new Vector3(1, 1, 1);

            //Text tempText = listItemText.GetComponent<Text>();
            int tempInt = i;

            //tempText.onClick.AddListener(() => ButtonClicked(tempInt));

            // for "Remove" buttons
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));

        }
    }

    // click item in inventory list
    public void readType()
    {
        if(buttonText.GetComponent<Text>().text == "Orange Juice")
        {
            itemHeader.GetComponent<Text>().text = "OJ";
        }
        else
        {
            itemHeader.GetComponent<Text>().text = buttonText.GetComponent<Text>().text;
        }
        
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }
}
