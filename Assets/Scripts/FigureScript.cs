using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureScript : MonoBehaviour
{

    private GameManagerScript gameManager;

    public int currentStep = -1;

    public GameObject child;
    private GameObject rotateGroup;

    List<GameObject> gameObjectList;

	// Use this for initialization
	void Start () {
       gameObjectList = new List<GameObject>();
       gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
       //rotateGroup = GameObject.Find("RotateGroup");

        GameObject initial = Instantiate(child, gameObject.transform.position, gameObject.transform.rotation);
        ElementScript script = initial.GetComponent<ElementScript>();
        script.SetLocalY(0);
        initial.transform.SetParent(rotateGroup.transform);
        gameObjectList.Add(initial);
    }
	
	// Update is called once per frame
	void Update () {

        if (currentStep != gameManager.GetStep())
        {
            //transform.Translate(new Vector3(1.25f, 0, 0));
            currentStep = gameManager.GetStep();

            for (int position = 0; position < gameObjectList.Count; position++)
            {
                ElementScript script = gameObjectList[position].GetComponent<ElementScript>();
                script.SetLocalX(currentStep);
            }
        }
	}

     public void AddElement(int step)
      {

        //Update();

        int activePosition = -1;
        int maxLocalY = -1;

        for (int position = 0; position < gameObjectList.Count; position++)
        {
            GameObject gameObject = gameObjectList[position];
            ElementScript script = gameObject.GetComponent<ElementScript>();

   
            if (script.localX == step)
            {
                if(maxLocalY < script.localY)
                {
                    activePosition = position;
                    maxLocalY = script.localY; 
                }
            }
        }

        addElementAtLocalPosition(gameObjectList[activePosition], maxLocalY + 1, step);
    }

    public void addElementAtLocalPosition(GameObject gameObject, int localY, int localX)
    {
        GameObject created = Instantiate(child, gameObject.transform.position, gameObject.transform.rotation);
        ElementScript script = created.GetComponent<ElementScript>();
        script.SetLocalY(localY);
        script.SetLocalX(localX);
        gameObjectList.Add(created);
    }

    public void RotateElement(int step)
    {

        //Update();

        int activePosition = -1;
        int activeY = -1;

        for (int position = 0; position < gameObjectList.Count; position++)
        {
            GameObject gameObject = gameObjectList[position];
            ElementScript script = gameObject.GetComponent<ElementScript>();

            if (script.localX == step)
            {
                if (activePosition == -1)
                {

                    activePosition = position;
                    activeY = script.localY;
                }
                else
                {
                    if (script.localY > activeY)
                    {
                        activePosition = position;
                        activeY = script.localY;
                    }
                }

            }
        }
        // ЗАКОММЕНТИЛ ВАЖНО, ОЛЕГ!
        //rotateGroup.transform.RotateAround(gameObjectList[activePosition].transform.position, new Vector3(0, 0, 1), -90);
        if (activeY > 0)
        {
            //rotateGroup.transform.Translate(Vector3.up * 1.25f * 2);
        }
    }

}
