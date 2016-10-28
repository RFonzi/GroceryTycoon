using UnityEngine;
using System.Collections;

public class SmallWindows : MonoBehaviour {

	public void SendToFront()
    {
        transform.SetAsLastSibling();
    }

    public void SendToBack()
    {
        transform.SetAsFirstSibling();
    }
}
