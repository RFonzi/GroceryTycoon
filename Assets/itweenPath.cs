using UnityEngine;
using System.Collections;

public class itweenPath : MonoBehaviour {
    public Transform[] waypointArray;
    public float percentsPerSecond = 0.02f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1
    public int deletePos;

    void Update()
    {
        if (waypointArray.Length > 0)
        {
            currentPathPercent += percentsPerSecond * Time.deltaTime;
            iTween.PutOnPath(gameObject, waypointArray, currentPathPercent);
            if (gameObject.transform.position.y < deletePos)
            {
                print("This just happened");
                Destroy(gameObject);
            }
        }
    }

    void OnDrawGizmos()
    {
        //Visual. Not used in movement
        iTween.DrawPath(waypointArray);
    }
}
