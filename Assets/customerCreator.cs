using UnityEngine;
using System.Collections;

public class customerCreator : MonoBehaviour {
    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;
    public Transform[] path4;
    public Transform[] path5;
    public Transform canvas;
    public GameObject customer;
    public int maxChildren;
    public float minTime = 5;
    public float maxTime = 20;

    private float time;
    private float randTime;

    // Use this for initialization
    void Start () {
        randTime = Random.Range(minTime, maxTime);
        time = minTime;
	}
	
	// Update is called once per frame
	void Update () {
	    if(canvas.childCount < maxChildren + 7)
        {
            if (time >= randTime)
            {
                time = 0;
                randTime = Random.Range(minTime, maxTime);
                GameObject cus = (GameObject) Instantiate(customer, new Vector3(-500, -500, 2), Quaternion.identity);
                cus.transform.parent = canvas;
                SpriteRenderer ren = cus.GetComponent<SpriteRenderer>();
                ren.color = new Color(Random.value, Random.value, Random.value, 1.0f);
                itweenPath itween = cus.GetComponent<itweenPath>();
                int pathNum = Random.Range(0, 5) + 1;
                switch (pathNum)
                {
                    case 1:
                        itween.waypointArray = path1;
                        break;
                    case 2:
                        itween.waypointArray = path2;
                        break;
                    case 3:
                        itween.waypointArray = path3;
                        break;
                    case 4:
                        itween.waypointArray = path4;
                        break;
                    case 5:
                        itween.waypointArray = path5;
                        break;
                }
            }
        }
        else
        {
        }

        time += Time.deltaTime;
    }
}
