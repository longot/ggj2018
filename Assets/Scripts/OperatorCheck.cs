using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorCheck : MonoBehaviour {
    public int activeStepLocalX = 7;

    public GameObject[] objects;
    public int[] yObjects;
    public int i;
    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update() {

    }

    void doshit()
    {
        objects = GameObject.FindGameObjectsWithTag("Block");

        int maxLocalY = -1;
        foreach (GameObject block in objects)
        {
            var coordinates = block.GetComponent<ElementScript>();
            if (activeStepLocalX == coordinates.localX)
            {
               
            }
        }

        if (maxLocalY != -1)
        {

            //Запускает функцию ротейта, эдда и другие функции операторов. 
            maxLocalY = -1;
        }
    }
}
