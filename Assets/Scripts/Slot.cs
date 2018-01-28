using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    private GameManagerScript gameManager;

	public int step;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }


    void Update()
    {
        
    }

    void OnMouseDown()
    {
        GameObject active = gameManager.getActiveTool();
		var t = active.GetComponent<TranformerScript>();
		t.SetActiveStep (step);
        active.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
    }
}