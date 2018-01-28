using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTransformerScript : MonoBehaviour {

    public int activeStep;
    public int interval;
    bool isExecuted;

    FigureScript figure;
    GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        figure = GameObject.Find("FigureGroup").GetComponent<FigureScript>();
    }
	
	// Update is called once per frame
	void Update () {

        if (gameManager.GetStep() == 0 || interval == 0)
        {
            return;
        }

        if (!isExecuted && gameManager.GetStep() % interval == 0)
        {
            isExecuted = figure.AddElement(activeStep);
        }
    }

    public void SetActiveStep(int step)
    {
        activeStep = step;
    }
}
