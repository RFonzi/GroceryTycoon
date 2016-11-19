using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public float rightBound;
    public float leftBound;
    public float topBound;
    public float bottomBound;
    private Vector3 pos;
    private Transform target;
    private bool mouseDown = false;
    private Vector3 startMousePos;
    private Vector3 startPos;
    // Use this for initialization
    void Start()
    {
        //target = GameObject.FindWithTag("Player").transform;
    }

    public void OnPointerDown()
    {
        Debug.Log("Pointer Down");
        mouseDown = true;
        startPos = transform.position;
        startMousePos = Input.mousePosition;
    }

    public void OnPointerUp()
    {
        Debug.Log("Pointer up");
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Right
        if (pos.x >= rightBound)
        {
            pos.x = rightBound;
        }
        //Left
        if (pos.x <= leftBound)
        {
            pos.x = leftBound;
        }
        //Top
        if (pos.y >= topBound)
        {
            pos.y = topBound;
        }
        //Bottom
        if (pos.y <= bottomBound)
        {
            pos.y = bottomBound;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(pos);
            Vector3 currentPos = Input.mousePosition;
            Vector3 diff = currentPos - startMousePos;
            pos = startPos + diff;
            transform.position = pos;
        }
    }
}
