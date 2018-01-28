using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementScript : MonoBehaviour {

    // 0..9
    public int localX = 0;
    // 0 ..2
    public int localY = 0;

	// Use this for initialization
	void Start () {
       
    }

    // Update is called once per frame

    void Update () {
        float unityY = 1.24f * localY;
        transform.position = new Vector3(transform.position.x, unityY, transform.position.z);

        float unityX = 1.24f * localX;
        transform.position = new Vector3(unityX, transform.position.y, transform.position.z);
    }

    public void SetLocalY(int y)
    {
        localY = y;
        
    }

    public void SetLocalX(int x)
    {
        localX = x;
        
    }

    public int getLocalY()
    {
        return localY;
    }
}
