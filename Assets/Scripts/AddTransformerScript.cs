using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTransformerScript : MonoBehaviour {

    int activeStep = 3;
    bool isExecuted;
    bool isExecuted2;
    FigureScript figure;
    GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        figure = GameObject.Find("FigureGroup").GetComponent<FigureScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isExecuted && activeStep == gameManager.GetStep())
        {
            isExecuted = true;
            figure.AddElement(gameManager.GetStep());
        }
        if (!isExecuted2 && gameManager.GetStep() == 5)
        {
            isExecuted2 = true;
            figure.AddElement(gameManager.GetStep());
        }
    }

    public void SetActiveStep(int step)
    {
        activeStep = step;
    }
}
