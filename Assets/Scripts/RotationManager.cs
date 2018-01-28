using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour {

    GameObject[] objects;

    public int RLocalX = 5; //потом искать эти переменные в скрипте оператора поворота.
    public int RLocalY = 5; //потом искать эти переменные в скрипте оператора поворота.
    public int offsetX;
    public int offsetY;
    public bool clockwise;
    // Use this for initialization
    void Start()
    {
        if (clockwise)
        {
            objects = GameObject.FindGameObjectsWithTag("Block");
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
        //Находим соседа, запоминаем его оффсет
        //Переводим оффсет в Локал координаты.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
