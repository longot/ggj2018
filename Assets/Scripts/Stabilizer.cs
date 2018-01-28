using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizer : MonoBehaviour {
    GameObject[] objects;
    public int upperGroundCounter;
    public int lowerGroundCounter;

    private GameManagerScript gameManager;
    // Use this for initialization
    int currentStep;

    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {

       
    }


    public void stabilize()
    {
        objects = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in objects)
        {
            var coordinates = block.GetComponent<ElementScript>();
            if (coordinates.localY != 0)
            {
                upperGroundCounter++;
            }
            if (coordinates.localY < 0)
            {
                lowerGroundCounter++;
                break;
            }
        }
        if (lowerGroundCounter > 0)
        {
            foreach (GameObject block in objects)
            {
                var coordinates = block.GetComponent<ElementScript>();
                coordinates.localY++;
            }
        }
        if (upperGroundCounter == objects.Length)
        {
            foreach (GameObject block in objects)
            {
                var coordinates = block.GetComponent<ElementScript>();
                coordinates.localY--;
            }
        }
        upperGroundCounter = 0;
        lowerGroundCounter = 0;

    }
}

//ЗАРАБОТАЕТ ПОСЛЕ ТОГО, КАК НАСТРОИМ ТРАНСФОРМ ПО ЛОКАЛХ И ЛОКАЛУ