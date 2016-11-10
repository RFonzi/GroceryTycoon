using UnityEngine;
using System.Collections;

public class SmallWindows : MonoBehaviour {
    public GameObject window;

	public void SendToFront()
    {
        window.SetActive(true);
        transform.SetAsLastSibling();
    }

    public void SendToBack()
    {
        window.SetActive(false);
        transform.SetAsFirstSibling();
    }
}
