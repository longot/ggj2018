using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransformationScript : MonoBehaviour {

    int activeStep = 7;
    bool isExecuted;
    FigureScript figure;
    GameManagerScript gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        figure = GameObject.Find("FigureGroup").GetComponent<FigureScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isExecuted && activeStep == gameManager.GetStep())
        {
            isExecuted = true;
            figure.RotateElement(gameManager.GetStep());
        }
    }

    public void SetActiveStep(int step)
    {
        activeStep = step;
    }
}
