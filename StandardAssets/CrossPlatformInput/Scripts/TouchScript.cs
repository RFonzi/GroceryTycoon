using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Touch myTouch = Input.GetTouch(0);

        
	}

    void OnGUI ()
    {
        foreach(TouchScript touch in Input.touches)
        {
            string message = "";
            message += "ID " + touch.fingerId + "\n";
        }
    }
}
