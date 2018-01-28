using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : TranformerScript {

    GameObject[] objects;

    public int interval = 1;
    bool isExecuted;

    public int RLocalX;
    public int RLocalY;
    public int offsetX;
    public int offsetY;
    public bool clockwise;

    GameManagerScript gameManager;
    Stabilizer stabilizer;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        stabilizer = GameObject.Find("FigureGroup").GetComponent<Stabilizer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (gameManager.GetStep() == 0 || interval == 0)
        {
            return;
        }


        if (!isExecuted && gameManager.GetStep() % interval == 0 && activeStep == gameManager.GetStep())
        {

            isExecuted = true;

            objects = GameObject.FindGameObjectsWithTag("Block");

            int maxLocalY = -1;
            for (int position = 0; position < objects.Length; position++)
            {
                GameObject gameObject = objects[position];
                ElementScript script = gameObject.GetComponent<ElementScript>();

                if (script.localX == gameManager.GetStep())
                {
                    if (maxLocalY < script.getLocalY())
                    {
                        maxLocalY = script.getLocalY();
                    }
                }
            }

            if(maxLocalY == -1)
            {
                return;
            }

            RLocalX = gameManager.GetStep();
            RLocalY = maxLocalY;

            if (clockwise)
            {              
                foreach (GameObject block in objects)
                {
                    var coordinates = block.GetComponent<ElementScript>();
                    offsetX = coordinates.localX - RLocalX;
                    offsetY = coordinates.localY - RLocalY;

                    coordinates.localX = RLocalX + offsetY; //по часовой
                    coordinates.localY = RLocalY - offsetX; //по часовой
                }
            }
            else
            {
                objects = GameObject.FindGameObjectsWithTag("Block");
                foreach (GameObject block in objects)
                {
                    var coordinates = block.GetComponent<ElementScript>();
                    offsetX = coordinates.localX - RLocalX;
                    offsetY = coordinates.localY - RLocalY;

                    coordinates.localX = RLocalX - offsetY; //против часовой
                    coordinates.localY = RLocalY + offsetX; //против часовой
                }
            }
            isExecuted = true;
            stabilizer.stabilize();
        }
    }
		
	void OnMouseDown()
	{
		gameManager.setActiveTool(gameObject);
	}
}
