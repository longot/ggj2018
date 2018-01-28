using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTransformerScript : TranformerScript {

    public int interval;
    bool isExecuted;

    FigureScript figure;
    GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        figure = GameObject.Find("FigureGroup").GetComponent<FigureScript>();
    }

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

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


        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

    void OnMouseDown()
    {
        gameManager.setActiveTool(gameObject);
    }
}
