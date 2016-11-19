using UnityEngine;
using System.Collections;

public class CreateObject : MonoBehaviour {
    public Rigidbody2D shelf;
    public Transform parent;
    public int x, y, z;

	// Use this for initialization
	void Start () {
        Vector3 pos = new Vector3(x, y, z);

        GameObject newShelf = (GameObject) Instantiate(shelf, pos, Quaternion.identity);
        newShelf.transform.SetParent(parent);
        newShelf.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
