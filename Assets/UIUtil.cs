using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIUtil : MonoBehaviour {
    public bool isImgOn;
    public GameObject obj;

	// Use this for initialization
	void Start () {
        obj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void disappear()
    {
        obj.SetActive(isImgOn);
    }
}
