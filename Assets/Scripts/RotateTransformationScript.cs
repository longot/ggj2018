using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransformationScript : TranformerScript {

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

    }

    public void SetActiveStep(int step)
    {
        activeStep = step;
    }

  
}
