using UnityEngine;
using System.Collections;

public class AutoSetCanvasCamera : MonoBehaviour {

    private bool isFound = false;

    void Update()
    {
        if (!isFound)
        {
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            if(!object.ReferenceEquals((this.gameObject.GetComponent<Canvas>().worldCamera = cam), null))
            {
                isFound = true;
                print("null");
            }
        }
    }
}
