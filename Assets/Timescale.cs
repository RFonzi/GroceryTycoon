using UnityEngine;
using System.Collections;

public class Timescale : MonoBehaviour {

    public Timestamp timestamp;
    public float timescaleOpen;
    public float timescaleClosed;

    public void Start() {

        //Load here, if a file doesn't exist create one with timestamp = 0

        //If timestamp isn't set, take a new one.
        if(timestamp == null) {
            timestamp = new Timestamp();
            timescaleOpen = 1.0f; //NUMBER IS PLACEHOLDER
            timescaleClosed = 0.1f; //NUMBER IS PLACEHOLDER
        }
        else {
            //Get diff and apply to our scale, add to our timestamp
            int sinceClose = (int)System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)).TotalSeconds;
            int diff = sinceClose - timestamp;
            int timestampNew = timestamp + (int)(diff * timescaleClosed);

            //Code to simulate from timestamp to timestampNew

            timestamp = timestampNew;
        }

    }

    public void Update() {
        //Determine how to increment time
    }

    public void OnApplicationQuit() {
        //Save current timestamp

    }

    public void OnApplicationPause(bool pause) {
        //Save current timestamp
    }

    public void OnApplicationFocus(bool focus) {

        //THIS IS THE SAME AS IN UPDATE(), PUT IT IN A FUNCTION??
        timestamp
        
        
    }

    public int fastforward() {

        //Get diff and apply to our scale, add to our timestamp
        int sinceClose = (int)System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)).TotalSeconds;
        int diff = sinceClose - timestamp;
        int timestampNew = timestamp + (int)(diff * timescaleClosed);

        //Code to simulate from timestamp to timestampNew

        timestamp = timestampNew;

    }
}
